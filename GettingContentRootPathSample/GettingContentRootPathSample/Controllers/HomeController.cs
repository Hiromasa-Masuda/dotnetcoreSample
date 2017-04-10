using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using GettingContentRootPathSample.Models;
using System.IO;
using System.Runtime.Serialization.Json;

namespace GettingContentRootPathSample.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// IHostingEnvironment のインスタンスを保持
        /// </summary>
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment = null;

        /// <summary>
        /// コンストラクター経由で、IHostingEnvironment のインスタンスを取得
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public HomeController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            //IHostingEnvironment をフィールドに保持
            this._hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            //シリアライザーのインスタンスを生成
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));

            string filePath = Path.Combine(this._hostingEnvironment.ContentRootPath, "Files", "person.json");
            
            Person deSerializedPerson = null;

            //入力ファイル ストリームの生成
            //using (FileStream stream = new FileStream(filePath, FileMode.Open))
            using (Stream stream = System.IO.File.Open(filePath, FileMode.Open))
            {
                //逆シリアライズ
                deSerializedPerson = jsonSerializer.ReadObject(stream) as Person;
            }

            return View(deSerializedPerson);
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
