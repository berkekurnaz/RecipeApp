using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;
using Recipe.MvcWebUI.AuthFilter;

namespace Recipe.MvcWebUI.Controllers
{
    [AdminAuthFilter]
    public class YoneticiAyarController : Controller
    {

        LDSettingManager settingManager = new LDSettingManager("Settings");

        private void CreateDefaultSetting()
        {
            Setting setting = new Setting();
            setting.Name = "SiteAdı";
            setting.Description = "Site Açıklama";
            setting.Mail = "Site Mail";
            settingManager.Add(setting);
        }

        public IActionResult Index(int Id = 1)
        {
            if (Id != 1)
            {
                Id = 1;
            }
            var item = settingManager.GetById(1);
            return View(item);
        }

        [HttpPost]
        public IActionResult AyarGuncelle(int Id, Setting setting)
        {
            var item = settingManager.GetById(1);
            item.Name = setting.Name;
            item.Description = setting.Description;
            item.Mail = setting.Mail;
            item.Phone = setting.Phone;
            item.Icon = setting.Icon;
            settingManager.Update(item);
            TempData["AyarGuncellemeMesaj"] = "Site Ayarları Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MedyaGuncelle(int Id, Setting setting)
        {
            var item = settingManager.GetById(1);
            item.Facebook = setting.Facebook;
            item.Instagram = setting.Instagram;
            item.Twitter = setting.Twitter;
            item.Youtube = setting.Youtube;
            settingManager.Update(item);
            TempData["AyarGuncellemeMesaj"] = "Site Ayarları Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SeoGuncelle(int Id, Setting setting)
        {
            var item = settingManager.GetById(1);
            item.SeoName = setting.SeoName;
            item.SeoDescription = setting.SeoDescription;
            item.SeoHeader = setting.SeoHeader;
            settingManager.Update(item);
            TempData["AyarGuncellemeMesaj"] = "Site Ayarları Başarıyla Güncellendi...";
            return RedirectToAction("Index");
        }

    }
}