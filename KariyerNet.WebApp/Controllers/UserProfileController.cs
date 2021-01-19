using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

namespace KariyerNet.WebApp.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserCurriculumVitaeService _userCurriculumVitaeService;
        private readonly IJobAdvertisementService _jobAdvertisementService;
        private readonly IUserDetailService _userDetailService;

        public UserProfileController(IUserService userService, IUserCurriculumVitaeService userCurriculumVitaeService, IJobAdvertisementService jobAdvertisementService, IUserDetailService userDetailService)
        {
            _userService = userService;
            _userCurriculumVitaeService = userCurriculumVitaeService;
            _jobAdvertisementService = jobAdvertisementService;
            _userDetailService = userDetailService;
        }

        public IActionResult GetUserProfileInformation()
        {
            var userProfile = new UserProfileViewModel();
            var user = _userService.GetUser();
            userProfile.userDetail = _userDetailService.GetEditUserDetail();
            userProfile.UserClaimViewModel = user;
            userProfile.UserPublishedCurriculumVitaeViewModel = _userCurriculumVitaeService.GetPublishedUserCurriculumVitaesByUserId(user.UserId);
            userProfile.UserCurriculumVitaeViewModels = _userCurriculumVitaeService.GetUserCurriculumVitaesByUserId(user.UserId);
            return View(userProfile);
        }
        public IActionResult GetUserCurriculumVitaes()
        {
            var user = _userService.GetUser();
            var userCurriculumVitaes = _userCurriculumVitaeService.GetUserCurriculumVitaesByUserId(user.UserId);
            return View(userCurriculumVitaes);
        }

        public IActionResult PublishUserCurriculumVitae(int curriculumVitaeId)
        {
            var user = _userService.GetUser();
            _userCurriculumVitaeService.PublishCurriculumVitae(user.UserId, curriculumVitaeId);
            return Redirect(Url.Action("GetUserCurriculumVitaes", "UserProfile"));
        }

        public IActionResult RemovePublishUserCurriculumVitae(int curriculumVitaeId)
        {
            var user = _userService.GetUser();
            _userCurriculumVitaeService.RemovePublishCurriculumVitae(user.UserId, curriculumVitaeId);
            return Redirect(Url.Action("GetUserCurriculumVitaes", "UserProfile"));
        }
        public IActionResult AddUserCurriculumVitae(AddUserCurriculumVitaeViewModel model, IFormFile file)
        {

            if (ModelState.IsValid && file != null)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new KeyValuePair<string, string>(x.Key, x.Value.Errors.FirstOrDefault().ErrorMessage)).ToList();

                var uploadedFileExtension = Path.GetExtension(file.FileName).ToLower();
                var acceptedFileExtensions = new List<string>()
                {
                        ".pdf"
                };

                //tanımladığınız dosya türleri arasında değil ise
                if (!acceptedFileExtensions.Contains(uploadedFileExtension))
                {
                    errors.Add(new KeyValuePair<string, string>("FilePath", "Düzgün dosya gir andaval!"));

                    return Json(new { message = $"{model.CVName} eklenemedi", status = false });
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserCurriculumVitaes", model.CVName.Replace(" ", "_") + Path.GetExtension(file.FileName));

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                model.FilePath = path;
                var checkErrors = _userCurriculumVitaeService.AddCurriculumVitae(model);

                if (checkErrors.Count == 0)
                {
                    return Json(new { redirect = "/UserProfile/GetUserCurriculumVitaes", message = $"{model.CVName} eklendi", status = true });
                }
                else
                {
                    return Json(new { message = checkErrors.First().Value, status = false });
                }


            }

            return Json(new { message = $"{model.CVName} eklenemedi", status = false });
        }



        public IActionResult CreateUserCurriculumVitae()
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Load the image as stream.
            string link= "~/UserProfileImages/alihan.png";
            string correctLink = Path.GetFullPath(link).Replace("~", "wwwroot");
            FileStream imageStream = new FileStream(correctLink, FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, 0, 60);


            //Set the standard font
            PdfFont hugeFont = new PdfStandardFont(PdfFontFamily.Helvetica, 24);
            PdfFont headerFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
            PdfFont arialFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);

            //Draw the text
            graphics.DrawString("kariyer.net", hugeFont, PdfBrushes.Purple, new PointF(350, 0));
            graphics.DrawString("Iletisim Bilgileri", headerFont, PdfBrushes.Gray, new PointF(0, 30));
            graphics.DrawString("Alihan Girgin", hugeFont, PdfBrushes.Black, new PointF(150, 60));
            graphics.DrawString("Bilgisayar Mühendisi", headerFont, PdfBrushes.Black, new PointF(150, 100));
            graphics.DrawString("E-Posta Adresi", arialFont, PdfBrushes.Gray, new PointF(150, 130));
            graphics.DrawString("Dogum Tarihi", arialFont, PdfBrushes.Gray, new PointF(350, 130));
            graphics.DrawString("alihangir@gmail.com", arialFont, PdfBrushes.Black, new PointF(150, 140));
            graphics.DrawString("15/06/1993", arialFont, PdfBrushes.Black, new PointF(350, 140));
            graphics.DrawString("Telefon", arialFont, PdfBrushes.Gray, new PointF(150, 160));
            graphics.DrawString("90 (532) 707 82 26", arialFont, PdfBrushes.Black, new PointF(150, 170));
            graphics.DrawString("Adres", arialFont, PdfBrushes.Gray, new PointF(150, 190));
            graphics.DrawString("Turkiye-Istanbul", arialFont, PdfBrushes.Black, new PointF(150, 200));

            graphics.DrawString("Özel Bilgiler", headerFont, PdfBrushes.Gray, new PointF(0, 230));
            graphics.DrawString("Cinsiyet", arialFont, PdfBrushes.Gray, new PointF(0, 280));
            graphics.DrawString("Erkek", arialFont, PdfBrushes.Black, new PointF(0, 290));
            graphics.DrawString("Uyruk", arialFont, PdfBrushes.Gray, new PointF(200, 280));
            graphics.DrawString("Türkiye", arialFont, PdfBrushes.Black, new PointF(200, 290));
            graphics.DrawString("Sürücü Belgesi", arialFont, PdfBrushes.Gray, new PointF(400, 280));
            graphics.DrawString("B", arialFont, PdfBrushes.Black, new PointF(400, 290));
            graphics.DrawString("Askerlik Durumu", arialFont, PdfBrushes.Gray, new PointF(0, 310));
            graphics.DrawString("Yapildi", arialFont, PdfBrushes.Black, new PointF(0, 320));


            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;
        }


        [HttpGet("download")]
        public IActionResult DownloadUserCurriculumVitae([FromQuery] string link, string nameSurname)
        {
            string correctLink = Path.GetFullPath(link).Replace("~", "wwwroot");
            var net = new System.Net.WebClient();
            var data = net.DownloadData(correctLink);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            string nameSurnameNormalized = nameSurname.Replace(" ", "");
            var fileName = nameSurnameNormalized + "CV.pdf";
            return File(content, contentType, fileName);
        }

        public IActionResult DeleteUserCurriculumVitae(int curriculumVitaeId)
        {
            _userCurriculumVitaeService.DeleteCurriculumVitae(curriculumVitaeId);
            return Redirect(Url.Action("GetUserCurriculumVitaes", "UserProfile"));
        }


        public IActionResult GetAdvertisementApplies()
        {

            var advertisementApplyList = _jobAdvertisementService.GetAdvertisementApplies();
            return View(advertisementApplyList);
        }

        public IActionResult EditUserDetail()
        {
            var userDetail = _userDetailService.GetEditUserDetail();
            return View(userDetail);
        }

        [HttpPost]
        public IActionResult EditUserDetail(EditUserDetailViewModel model)
        {
            if (ModelState.IsValid && model.ProfileImageFile != null)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new KeyValuePair<string, string>(x.Key, x.Value.Errors.FirstOrDefault().ErrorMessage)).ToList();

                var uploadedFileExtension = Path.GetExtension(model.ProfileImageFile.FileName).ToLower();
                var acceptedFileExtensions = new List<string>()
                {
                        ".png",
                        ".jpg",
                        ".gif",
                        ".bmp",
                        ".jpeg"
                };

                //tanımladığınız dosya türleri arasında değil ise
                if (!acceptedFileExtensions.Contains(uploadedFileExtension))
                {
                    errors.Add(new KeyValuePair<string, string>("ProfileImageFile", "Düzgün dosya gir andaval!"));

                    return View();
                }
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserProfileImages", model.ProfileImageFile.FileName.Replace(" ", "_") + "");/* + Path.GetFileNameWithoutExtension(model.ProfileImageFile.FileName))*/

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.ProfileImageFile.CopyTo(stream);
                }
                model.ProfileImage = path;

            }

          
            _userDetailService.EditUserDetail(model);
            var userDetail = _userDetailService.GetEditUserDetail();
            return View(userDetail);
        }
       
    }

}

