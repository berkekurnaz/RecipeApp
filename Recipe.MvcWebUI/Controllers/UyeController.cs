using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using Recipe.MvcWebUI.AuthFilter;
using Recipe.MvcWebUI.Models;

namespace Recipe.MvcWebUI.Controllers
{
    public class UyeController : Controller
    {

        public LDArticleManager articleManager = new LDArticleManager("Articles");
        public LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        public LDUserManager userManager = new LDUserManager("Users");
        public LDCommentManager commentManager = new LDCommentManager("Comments");

        /* Uye Giris Ekrani Ve Islemi */
        public IActionResult Giris()
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles()
            };
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Giris(User user)
        {
            var newUser = userManager.Login(user);
            if (newUser != null)
            {
                HttpContext.Session.SetString("SessionUserId", newUser.Id.ToString());
                HttpContext.Session.SetString("SessionUserUsername", newUser.Username);
                HttpContext.Session.SetString("SessionUserNameSurname", newUser.NameSurname);
                return RedirectToAction("Profil");
            }
            TempData["UyeGirisHataMesaj"] = "Kullanıcı Adını Veya Şifrenizi Yanlış Girdiniz.";
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles()
            };
            return View(userViewModel);
        }

        /* Uye Olma Ekrani Ve Islemi */
        public IActionResult UyeOl()
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles()
            };
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult UyeOl(User user)
        {
            var newUser = userManager.CheckByMail(user);
            if (newUser == null)
            {
                newUser = userManager.CheckByUsername(user);
                if (newUser == null)
                {
                    user.CreatedDate = DateTime.Now.ToShortDateString();
                    user.Photo = "defaultuser.png";
                    userManager.Add(user);
                    TempData["UyeOlmaBasariMesaj"] = "Başarı İle Üye Oldunuz.Artık Giriş Yapabilirsiniz.";
                    return RedirectToAction("Giris");
                }
            }
            TempData["UyeOlmaHataMesaj"] = "Daha Önce Bu Sisteme Bu Kullanıcı Adı Veya Mail Adresi İle Kayıt Olunmuş.Lütfen Farklı Kullanıcı Adı Veya Mail Adresi Giriniz.";
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles()
            };
            return View(userViewModel);
        }

        /* Uyenin Profil Ekrani */
        [UserAuthFilter]
        public IActionResult Profil()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles(),
                User = userManager.GetById(userId)
            };
            return View(userViewModel);
        }

        /* Uyenin Yorumlar Ekrani */
        public IActionResult Yorumlar()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            CommentViewModel commentViewModel = new CommentViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles(),
                User = userManager.GetById(userId),
                Comments = commentManager.GetAllByUser(userId)
            };
            return View(commentViewModel);
        }

        /* Uyenin Yorum Detay Ekrani */
        public IActionResult YorumDetay(int Id)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var comment = commentManager.GetById(Id);
            if (comment == null)
            {
                return RedirectToAction("Hata", "Anasayfa");
            }
            if (comment.User.Id != userId)
            {
                return RedirectToAction("Hata", "Anasayfa");
            }
            CommentViewModel commentViewModel = new CommentViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles(),
                User = userManager.GetById(userId),
                Comments = commentManager.GetAllByUser(userId),
                comment = comment
            };
            return View(commentViewModel);
        }

        [HttpPost]
        public IActionResult YorumSil(int Id)
        {
            commentManager.Delete(Id);
            TempData["YorumSilmeMesaj"] = "Yorum Başarıyla Silindi.";
            return RedirectToAction("Yorumlar");
        }

        /* Uyenin Profil Duzenleme Ekrani Ve Islemi */
        [UserAuthFilter]
        public IActionResult Duzenle()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles(),
                User = userManager.GetById(userId)
            };
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Duzenle(User user)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var item = userManager.GetById(userId);
            item.NameSurname = user.NameSurname;
            item.Mail = user.Mail;
            item.Username = user.Username;
            userManager.Update(item);
            TempData["UyeGuncellemeBasariMesaj"] = "Üye Bilgileriniz Başarıyla Güncellendi.";
            return RedirectToAction("Profil");
        }

        /* Uyenin Profil Fotografi Duzenleme Ekrani Ve Islemi */
        [UserAuthFilter]
        public IActionResult Fotograf()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles(),
                User = userManager.GetById(userId)
            };
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Fotograf(User user, IFormFile Image)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var item = userManager.GetById(userId);
            if (Image != null)
            {
                if (item.Photo != "defaultuser.png")
                {
                    if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\Uye\\" + item.Photo))
                    {
                        System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\Uye\\" + item.Photo);
                    }
                }
                string newImage = Guid.NewGuid().ToString() + Image.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uye", newImage);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                item.Photo = newImage;
            }
            userManager.Update(item);
            TempData["UyeFotografBasariMesaj"] = "Üye Profil Fotoğrafı Başarıyla Güncellendi.";
            return RedirectToAction("Profil");
        }

        /* Uyenin Sifresini Duzenleme Ekrani Ve Islemi */
        [UserAuthFilter]
        public IActionResult SifreDuzenle()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles(),
                User = userManager.GetById(userId)
            };
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult SifreDuzenle(string oldPassword, string newPassword)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var item = userManager.GetById(userId);
            if (item.Password == oldPassword)
            {
                item.Password = newPassword;
                userManager.Update(item);
                TempData["UyeSifreBasariMesaj"] = "Üye Şifresi Başarıyla Güncellendi.";
                return RedirectToAction("Profil");
            }
            else
            {
                TempData["UyeSifreHataMesaj"] = "Lütfen Önceki Şifrenizi Doğru Giriniz.";
            }
            UserViewModel userViewModel = new UserViewModel()
            {
                Categories = categoryManager.GetAll(),
                MostPopular = articleManager.GetMostPopularArticles(),
                User = userManager.GetById(userId)
            };
            return View(userViewModel);
        }

    }
}