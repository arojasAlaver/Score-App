using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Services.Classes
{
    public class EmailNotifyClass : IEmailNotify
    {
        public EmailNotifyClass(IConfiguration Configuration, IWebHostEnvironment env)
        {
            _Configuration = Configuration;
            _env = env;

        }
        private readonly IConfiguration _Configuration;
        private readonly IWebHostEnvironment _env;
        public void SendEmail(Application app)
        {
            var message = new MailMessage();
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            message.From = new MailAddress(app.ExecutiveAssigned.Mail, app.ExecutiveAssigned.DisplayName);
            message.To.Add(new MailAddress(app.OfficialAssignTo.Mail, app.OfficialAssignTo.DisplayName, Encoding.UTF8));
            message.Subject = "¡Nuevo Caso Asignado Score App! ✔️";

            var image2 = new LinkedResource(Path.Combine(_env.WebRootPath,_Configuration["Configs:ImagePath"], "alaverLogo.png"));
            image2.ContentId = "image2";

            var twitter = new LinkedResource(Path.Combine(_env.WebRootPath, _Configuration["Configs:ImagePath"], "Twitter.png"));
            twitter.ContentId = "twitter";

            var facebook = new LinkedResource(Path.Combine(_env.WebRootPath, _Configuration["Configs:ImagePath"], "Facebook.png"));
            facebook.ContentId = "facebook";

            var instagram = new LinkedResource(Path.Combine(_env.WebRootPath, _Configuration["Configs:ImagePath"], "Instagram.png"));
            instagram.ContentId = "instagram";

            var you_tube = new LinkedResource(Path.Combine(_env.WebRootPath, _Configuration["Configs:ImagePath"], "You_tube.png"));
            you_tube.ContentId = "you_tube";


            AlternateView AltView = AlternateView.CreateAlternateViewFromString(prepareEmail(image2, twitter, facebook, instagram, you_tube, app), null, "text/html");
            AltView.LinkedResources.Add(image2);
            AltView.LinkedResources.Add(twitter);
            AltView.LinkedResources.Add(facebook);
            AltView.LinkedResources.Add(instagram);
            AltView.LinkedResources.Add(you_tube);

            message.AlternateViews.Add(AltView);
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.OnSuccess;



            using (var client = new System.Net.Mail.SmtpClient())
            {
                client.Host = _Configuration["ServerConfigs:Server"];
                client.Port = Convert.ToInt32(_Configuration["ServerConfigs:Port"]);
                client.EnableSsl = false;
                client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.Send(message);

            }
        }


        private string prepareEmail(LinkedResource image2, LinkedResource twitter, LinkedResource facebook, LinkedResource instagram, LinkedResource you_tube, Application app)
        {
            try
            {

                return "<!DOCTYPE html>"
                        + "<html lang=\"en\">"
                        + "  <head>"
                        + "    <meta charset=\"UTF - 8\" /> "
                        + "    <meta name=\"viewport\" content =\"width=device-width, initial-scale=1.0\" />"
                        + "    <meta http-equiv=\"X-UA-Compatible\" content =\"IE=Edge,chrome=1\" />"
                        + "    <link href=\"https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap.min.css\" rel=\"stylesheet\"/>"
                        + "    <link href=\"https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.19.1/css/mdb.min.css\" rel=\"stylesheet\"/>"
                        + "    <title>Alaver</title>"
                        + "    <style>"
                        + "      .h2,.h3,.h4 {\"font-family: \"Times New Roman\", Times, serif;\"}"
                        + "    </style>"
                        + "  </head>"
                         + $"  <body> "
                         + "    <div class=\"row\">"
                         + "      <div class=\"col-12\">"
                         + "        <div class=\"d-flex justify-content-center\">"
                         + $"          <img src=\"cid:{image2.ContentId}\" />"
                         + "        </div>"
                         + "      </div>"
                         + "    </div>"
                         + "    <div class=\"row\">"
                         + "      <div class=\"col-12\">"
                         + "        <div class=\"d-flex justify-content-center text-center\">"
                         + "          <p style=\"margin-left: 2%;\">"
                         + "            <h2 class=\"display-4\">Un nuevo caso ha sido asignado a su usuario</h2>"
                         + "              <br/><br/>"
                         + $"              <b>Ejecutivo:</b> {app.ExecutiveAssigned.DisplayName}<br/>" +
                           $"<b>Oficial:</b> {app.OfficialAssignTo.DisplayName}<br/><b>Caso No:</b> {app.Id}" +
                           $"<br/><b>Cliente:</b> {app.Person.LastNames},{app.Person.Names}<br/><b>Cédula:</b> {app.Person.Id}<br/>" +
                           "     <a class='btn btn-secondary' href='https://localhost:44351/75e56f57-3036-460f-b3c4-d3789e0fd5fc'>Ir</a> <br/><br/>Para"
                         + "     mayor información de nuestros servicios y productos."
                         + "          </p>"
                         + "        </div>"
                         + "      </div>"
                         + "    </div>"
                         + "    <div class=\"row\">"
                         + "      <div class=\"col-12\">"
                         + "        <div class=\"d-flex justify-content-center text-center\">"
                         + $"          <a style=\"margin-right: 2%;\" href =\"{_Configuration["Accounts:Twitter"]}\"><img src=\"cid:{twitter.ContentId}\"/></a>"
                         + $"          <a style=\"margin-right: 2%;\" href =\"{_Configuration["Accounts:Facebook"]}\"><img src=\"cid:{facebook.ContentId}\"/></a>"
                         + $"          <a style=\"margin-right: 2%;\" href=\"{_Configuration["Accounts:Instagram"]}\"><img src=\"cid:{instagram.ContentId}\"/></a>"
                         + $"          <a style=\"margin-right: 2%;\" href=\"{_Configuration["Accounts:Youtube"]}\"><img src=\"cid:{you_tube.ContentId}\"/></a>"
                         + "        </div>"
                         + "      </div>"
                         + "    </div>"
                         + "    <hr class=\"my-4\" /> "
                         + "    <div class=\"row\" > "
                         + "      <div class=\"col-12\" > "
                         + "        <div class=\"d-flex justify-content-center text-center\" > "
                         + "          <font face=\"Arial\" color =\"Gray\" size =\"1\""
                            + "            ><br />"
                            + "            Este mensaje puede contener información privilegiada y confidencial."
                            + "            Dicha información es exclusiva para el individuo o entidad al cual"
                            + "            es enviada. Si el lector de este mensaje no es el destinatario del"
                            + "            mismo, queda formalmente notificado que cualquier divulgación,"
                            + "            distribución, reproducción o copiado de esta comunicación está"
                            + "            estrictamente prohibido. Si este es el caso, favor eliminar el"
                            + "            mensaje de su computadora e informar al emisor a través de un"
                            + "            mensaje de respuesta. Las opiniones expresadas en este mensaje son"
                            + "            propias del autor y no necesariamente coinciden con las de ALAVER<br />"
                            + "            <br />"
                            + "            Gracias.<br />"
                            + "            ALAVER<br />"
                            + "            <br />"
                            + "            <br />"
                            + "            This message may contain information that is privileged and"
                            + "            confidential. It is intended only for the use of the individual or"
                            + "            entity to which it is addressed. If the reader of this message is"
                            + "            not the intended recipient, you are hereby notified that any"
                            + "            dissemination, distribution, reproduction or copying of this"
                            + "            communication is strictly prohibited. If this is the case, please"
                            + "            proceed to destroy the message from your computer and inform the"
                            + "            sender through reply mail. Information in this message that does not"
                            + "            directly relate to the official business of the company shall be"
                            + "            understood as neither given nor endorsed by it.<br />"
                            + "            <br />"
                            + "            Thank you.<br />"
                            + "            ALAVER<br />"
                            + "          </font>"
                            + "        </div>"
                            + "      </div>"
                            + "    </div>"
                            + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js\"></script>"
                             + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.4/umd/popper.min.js\"></script>"
                              + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/js/bootstrap.min.js\"></script>"
                               + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.19.1/js/mdb.min.js\"></script>"
                                + "  </body>"
                                + "</html>";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void NotifyEmail(List<string> Fails, int Total, int Enviados, string error)
        {
            try
            {
                var EmailNotifyList = _Configuration.GetSection("Configs:EmailsNotify").Get<string[]>();

                var message = new MailMessage();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                message.From = new MailAddress(_Configuration["ServerConfigs:From_Email"], _Configuration["ServerConfigs:From_Name"]);
                foreach (string email in EmailNotifyList)
                {
                    message.To.Add(new MailAddress(email));

                }

                message.Subject = "Resultados de Notificación de Cumpleaños";

                message.Body = prepareNotifyHtml(Fails, Total, Enviados, error);

                using (var client = new System.Net.Mail.SmtpClient())
                {
                    client.Host = _Configuration["ServerConfigs:Server"];
                    client.Port = Convert.ToInt32(_Configuration["ServerConfigs:Port"]);
                    client.EnableSsl = false;
                    client.DeliveryFormat = SmtpDeliveryFormat.International;
                    client.Send(message);

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private string prepareNotifyHtml(List<string> Fails, int Total, int Enviados, string error)
        {
            try
            {
                var returned = "<!DOCTYPE html>"
                        + "<html lang=\"en\">"
                        + "  <head>"
                        + "    <meta charset=\"UTF - 8\" />"
                        + "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />"
                        + "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge,chrome=1\" />"
                        + "    <link href=\"https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap.min.css\" rel=\"stylesheet\" />"
                        + "    <link href=\"https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.19.1/css/mdb.min.css\" rel=\"stylesheet\"/>"
                        + "    <title>Alaver</title>"
                        + "    <style>"
                        + "      .h2,"
                        + "      .h3,"
                        + "      .h4 {"
                        + "        font-family: \"Times New Roman\", Times, serif;"
                        + "      }"
                        + "    </style>"
                        + "  </head>"
                        + "  <body>"
                        + "    <div class=\"row\">"
                        + "      <div class=\"col-12\">"
                        + "        <div class=\"d-flex justify-content-center text-center\">"
                        + "          <p style=\"margin-left: 2%; color: #0d47a1;\"><text class=\"display-4\">Resultados de Notificación de Cumpleaños</text><br /><br />"
                        + $"            <b>Total General de Clientes:&nbsp</b>{Total}<br />"
                        + $"            <b>Total de Envíos Exitosos:&nbsp</b>{Enviados}<br />"
                        + $"            <b>Total de Envíos Fallidos:&nbsp</b>{Fails.Count}<br /><br />";
                if (Fails.Count > 0)
                {
                    returned += "            <text class=\"display-4\" > Listado de Correos Fallidos </ text > <br>";
                }

                foreach (var row in Fails)
                {
                    returned += $"{row}<br>";
                }
                if (!String.IsNullOrEmpty(error))
                {
                    returned += "            <text class=\"display-4\" > Error de envio </ text > <br>";
                    returned += $"{error}<b><b>";
                }

                returned += " </p>"
                + "        </div>"
                + "      </div>"
                + "    </div>"
                + "    <hr class=\"my-4\" />"
                + "    <div class=\"row\">"
                + "      <div class=\"col-12\">"
                + "        <div class=\"d-flex justify-content-center text-center\">"
                + "          <font face=\"Arial\" color=\"Gray\" size=\"1\""
                + "            ><br />"
                + "            Este mensaje puede contener información privilegiada y confidencial."
                + "            Dicha información es exclusiva para el individuo o entidad al cual"
                + "            es enviada. Si el lector de este mensaje no es el destinatario del"
                + "            mismo, queda formalmente notificado que cualquier divulgación,"
                + "            distribución, reproducción o copiado de esta comunicación está"
                + "            estrictamente prohibido. Si este es el caso, favor eliminar el"
                + "            mensaje de su computadora e informar al emisor a través de un"
                + "            mensaje de respuesta. Las opiniones expresadas en este mensaje son"
                + "            propias del autor y no necesariamente coinciden con las de ALAVER<br />"
                + "            <br />"
                + "            Gracias.<br />"
                + "            ALAVER<br />"
                + "            <br />"
                + "            <br />"
                + "            This message may contain information that is privileged and"
                + "            confidential. It is intended only for the use of the individual or"
                + "            entity to which it is addressed. If the reader of this message is"
                + "            not the intended recipient, you are hereby notified that any"
                + "            dissemination, distribution, reproduction or copying of this"
                + "            communication is strictly prohibited. If this is the case, please"
                + "            proceed to destroy the message from your computer and inform the"
                + "            sender through reply mail. Information in this message that does not"
                + "            directly relate to the official business of the company shall be"
                + "            understood as neither given nor endorsed by it.<br />"
                + "            <br />"
                + "            Thank you.<br />"
                + "            ALAVER<br />"
                + "          </font>"
                + "        </div>"
                + "      </div>"
                + "    </div>"
                + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js\" ></script>"
                + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.4/umd/popper.min.js\" ></script>"
                + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/js/bootstrap.min.js\" ></script>"
                + "    <script type=\"text / javascript\" src=\"https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.19.1/js/mdb.min.js\" ></script>"
                + "  </body>"
                + "</html>";

                return returned;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
