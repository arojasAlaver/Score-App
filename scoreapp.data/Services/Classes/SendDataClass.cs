using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Xml;
using Microsoft.AspNetCore.DataProtection;
using scoreapp.model.enums;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;
using scoreapp_model_enums;

namespace scoreapp.data.Services.Classes
{
    public class SendDataClass : ISendData
    {
        private readonly Context _db;
        private readonly IDataProtectionProvider _provider;
        private readonly List<Config> _allSettings;
        public SendDataClass(Context db, IDataProtectionProvider provider)
        {
            _db = db;
            _allSettings = _db.Settings.ToList();
            _provider = provider;
        }
        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }


        public Boolean searchForValue(string data, decimal age)
        {
            if (data.Contains(">="))
            {
                return age >= Convert.ToDecimal(data[2..]);
            }
            else if (data.Contains("<="))
            {
                return age <= Convert.ToDecimal(data[2..]);
            }
            else if (data.Contains("=="))
            {
                return age == Convert.ToDecimal(data[2..]);
            }
            else if (data.Contains(">"))
            {
                return age > Convert.ToDecimal(data[1..]);
            }
            else if (data.Contains("<"))
            {
                return age < Convert.ToDecimal(data[1..]);
            }
            return false;
        }

        public async Task<Person> Store(Person app)
        {
            var personExist = _db.Persons.AsNoTracking().SingleOrDefault(x => x.Id == app.Id);
            IDataProtector _protector = _provider.CreateProtector(Config.private_key);

            int score = 0;
            score += _db.Variables.AsNoTracking().SingleOrDefault(x => x.Description.ToLower().Replace("_", " ")
            == ((Nationality)app.Nationality).ToString().ToLower().Replace("_", " ")).Score;
            score += _db.Variables.AsNoTracking().SingleOrDefault(x => x.Description.ToLower().Replace("_", " ")
            == ((Marital_Status)app.Marital_Status).ToString().ToLower().Replace("_", " ")).Score;

            score += _db.Variables.AsNoTracking().SingleOrDefault(x => x.Description.ToLower().Replace("_", " ")
            == ((Type_Job)app.Jobs.First().TypeJob).ToString().ToLower().Replace("_"," ")).Score;

            score += _db.Variables.AsNoTracking().SingleOrDefault(x => x.Description.ToLower().Replace("_", " ")
            == ((Municipality)app.Municipality).ToString().ToLower().Replace("_", " ")).Score;

            score += _db.Variables.AsNoTracking().SingleOrDefault(x => x.Description.ToLower().Replace("_", " ")
            == ((Dependents)app.Dependents).ToString().ToLower().Replace("_", " ")).Score;

            score += _db.Variables.AsNoTracking().SingleOrDefault(x => x.Description.ToLower().Replace("_", " ")
            == ((Type_Dwelling)app.Dwelling).ToString().ToLower().Replace("_", " ")).Score;

            score += _db.Variables.AsNoTracking().SingleOrDefault(x => x.Description.ToLower().Replace("_", " ")
            == ((Type_Activity)app.Jobs.First().TypeActivity).ToString().ToLower().Replace("_", " ")).Score;




            app.Applications.First().Score = score;

            if (personExist == null)
            {
                app.LastDateBuroConsult = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                app.Buro = personBuro(app.Id).OuterXml;
                app.Applications.First().Score += DatacreditoScore(app);
                await _db.Persons.AddAsync(app);


            }
            else
            {
                if (personExist.LastDateBuroConsult == null || (DateTime.Now - (DateTime)personExist.LastDateBuroConsult).TotalDays >
                    Convert.ToInt32(_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Buro.TotalDays").Value)))
                {
                    app.LastDateBuroConsult = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    app.Buro = personBuro(app.Id).OuterXml;
                    app.Applications.First().Score += DatacreditoScore(app);
                }
                else
                {
                    app.LastDateBuroConsult = personExist.LastDateBuroConsult;
                    app.Buro = personExist.Buro;
                    app.Applications.First().Score += DatacreditoScore(app);
                }

                if (app.Applications.First().Score <
                    Convert.ToInt32(
                        _protector.Unprotect(_allSettings
                        .SingleOrDefault(x => _protector
                        .Unprotect(x.Setting) == "Score.Accepted").Value)))
                {
                    app.Applications.First().Status = Application_Status.Rechazado;
                }
                    

                _db.Persons.Attach(app);
                _db.Entry(app).State = EntityState.Modified;
                
                
            }


            return app;
        }



        public XmlDocument personBuro(string Id)
        {
            IDataProtector _protector = _provider.CreateProtector(Config.private_key);
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxBufferSize = int.MaxValue;
            binding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.AllowCookies = true;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.UseDefaultWebProxy = false;
            binding.ProxyAddress = new UriBuilder()
            {
                Host = _protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "ProxyHost").Value),
                Port = Convert.ToInt32(_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "ProxyPort").Value))
            }.Uri;


            clsCaltecServiceSoapClient cs = new clsCaltecServiceSoapClient(binding, new EndpointAddress(
                _protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Buro.Api").Value)));


            StringBuilder sb = new StringBuilder();

            sb.AppendLine(cs.GetXml(_protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Buro.Username").Value),
                _protector.Unprotect(_allSettings.SingleOrDefault(x => _protector.Unprotect(x.Setting) == "Buro.Password").Value), "C", Id.Trim().Replace("-", "")));

            XmlDocument document = null;
            if (sb.ToString().Length > 0)
            {
                document = new XmlDocument();
                document.LoadXml(sb.ToString().ToLower());
            }


            return document;
        }

        public int DatacreditoScore(Person app)
        {
            

                
            int score = 0;

            decimal capacidad = app.Applications.First().Incomes + app.Applications.First().OtherIncomes ?? 0;
            decimal cuota = app.Applications.First().Amount / app.Applications.First().Terms ?? 0;

            int age = DateTime.Now.Year - app.BornDate.Value.Year;
            age -= Convert.ToInt32(DateTime.Now.Date < app.BornDate.Value.Date.AddYears(age));
            decimal deudas = Convert.ToDecimal(0);
            IDictionary<string, decimal> datas = new Dictionary<string, decimal>();
            if (!string.IsNullOrEmpty(app.Buro))
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(app.Buro);

                foreach (System.Xml.XmlNode node in document["dcr"].SelectSingleNode("//producto[@cod='pre']"))
                {

                    if (node.SelectSingleNode("estatusultimo").InnerText.ToLower() == "vigente")
                    {
                        if (node.SelectSingleNode("cuota").InnerText != "")
                        {
                            deudas += Convert.ToDecimal(node.SelectSingleNode("cuota").InnerText);
                        }
                    }
                }

                datas.Add("buro_score", Convert.ToInt32(((XmlNode)document["dcr"].SelectSingleNode("xcore_pd12m_all_pc_nc_global/xcore")).InnerText));
                datas.Add("duracion_atrasos_mas_reciente", Convert.ToInt32(Regex.Matches(!string.IsNullOrEmpty(((XmlNode)document["dcr"]
                  .SelectSingleNode("analisiscrediticio/analisisatrasos/moneda[@id='rd']/masreciente/diasatraso")).InnerText) ?
                  ((XmlNode)document["dcr"]
                  .SelectSingleNode("analisiscrediticio/analisisatrasos/moneda[@id='rd']/masreciente/diasatraso")).InnerText : "0", @"\d+")[0]
                  .ToString()));

                datas.Add("monto_vencimiento_mas_reciente", DateTime.ParseExact(((XmlNode)document["dcr"]
                .SelectSingleNode("analisiscrediticio/analisisatrasos/moneda[@id='rd']/masreciente/fecha")).InnerText, "MM-yyyy", CultureInfo.CurrentCulture) >=
                DateTime.ParseExact(((XmlNode)document["dcr"]
                .SelectSingleNode("analisiscrediticio/analisiscreditos/moneda[@id='rd']/masreciente/fecha")).InnerText, "MM-yyyy", CultureInfo.CurrentCulture) ?

                    Convert.ToDecimal((100 / Convert.ToInt32(((XmlNode)document["dcr"]
                .SelectSingleNode("analisiscrediticio/analisiscreditos/moneda[@id='rd']/masreciente/monto")).InnerText.Replace("$", ""))) *
                Convert.ToInt32(((XmlNode)document["dcr"]
                .SelectSingleNode("analisiscrediticio/analisisatrasos/moneda[@id='rd']/masreciente/monto")).InnerText.Replace("$", ""))) : 0);
            }
            

            
            
            
            

            datas.Add("capacidad_endeudamiento", Math.Round(cuota / (capacidad - deudas),2));

            datas.Add("edades", age);

            int timeInCompany = app.Jobs.First().TimeInCompany != 0 ? app.Jobs.First().TimeInCompany / 12 : 0;
            if (timeInCompany != 0)
            {
                datas.Add("tiempo_laborando",timeInCompany);
            }




            foreach (var item in datas)
            {
                var obj = _db.Variables.Where(x => x.Group.Description.ToLower().Replace(" ", "_") == item.Key.ToString()).Select(x => new
                {
                    Variables = x.Description,
                    Score = x.Score
                }).ToList();

                for (int i = 0; i < obj.Count; i++)
                {
                    string[] data = obj[i].Variables.ToLower().Split("x");
                    data = data.Where(x => !string.IsNullOrEmpty(x)).ToArray();



                    if (data.Count() > 1)
                    {
                        if (searchForValue(data[0], item.Value) && searchForValue(data[1], item.Value))
                        {
                            score += Convert.ToInt32(obj[i].Score);
                            break;
                        }

                    }
                    else
                    {
                        if (searchForValue(data[0], item.Value))
                        {
                            score += Convert.ToInt32(obj[i].Score);
                            break;
                        }
                    }

                }
            }
            
            
            return score;
        }
    }
}
