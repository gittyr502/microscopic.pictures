using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PicturesDL : IPicturesDL
    {
        MicroscopicPicture1Context myDB;
        ExamDL examDL;

        public PicturesDL(MicroscopicPicture1Context _myDB)
        {
            myDB = _myDB;
        }
        public async Task Post(PicturesCollection picture)
        {
            await myDB.PicturesCollections.AddAsync(picture);
            await myDB.SaveChangesAsync();

            //שליחה לאלגוריתם
            //await myDB.Users.Where(u=> u.;
            //MailMessage message = new MailMessage();
            //    message.From = new MailAddress("212853055@mby.co.il");
            //    message.To.Add(new MailAddress([i].Email));
            //    message.Attachments.Add(new Attachment("M:\\q.jpg"));
            //    string mailbody = "The resault is";
            //    string link = "<a href= https://localhost:44369/swagger/index.html > enter to match  </a>";
            //    message.Subject = "Hello " ;
            //    message.Attachments.Add(new Attachment("M:\\q.jpg"));

            //    message.Body = mailbody + link;
            //    message.BodyEncoding = Encoding.UTF8;
            //    message.IsBodyHtml = true;
            //    SmtpClient client = new SmtpClient("smtp.live.com", 587); //Gmail smtp    
            //    System.Net.NetworkCredential basicCredential1 = new
            //    System.Net.NetworkCredential("324861285@mby.co.il", "Student@264");
            //    client.EnableSsl = true;
            //    client.UseDefaultCredentials = false;
            //    client.Credentials = basicCredential1;


            //    try
            //    {
            //        client.Send(message);
            //    }

            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }


        }

        //public Task SaveUserImage(UserImage img)
        //{

        //        myDB.UserImages.Add(img);
        //        myDB.SaveChanges();
        //    return true;
        //}

        public async Task<bool> ImgExist(string linkToFile)
        {
            return await examDL.ImgExist(linkToFile);
        }
    }
}
