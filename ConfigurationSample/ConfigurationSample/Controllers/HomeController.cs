using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigurationSample.AppSettings;
using Microsoft.Extensions.Options;

namespace ConfigurationSample.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// ユーザー設定情報を保持
        /// </summary>
        private readonly UserSettings _userSettings = null;
        private readonly PageSettings _pageSettings = null;

        /// <summary>
        /// コンストラクターを定義し、引数に構成情報を取得するクラスを定義する。
        /// </summary>
        /// <param name="userSettings"></param>
        /// <param name="pageSettings"></param>
        public HomeController(IOptions<UserSettings> userSettings, IOptions<PageSettings> pageSettings)
        {
            //ユーザー設定情報インスタンスをフィールドに保持
            this._userSettings = userSettings.Value;
            this._pageSettings = pageSettings.Value;
        }

        public IActionResult Index()
        {
            return View(this._userSettings);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
