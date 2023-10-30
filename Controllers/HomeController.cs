using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;

namespace BookFinderApp.Controllers
{
    public class HomeController : Controller
    {
        private const string xmlString = @"
            <Books>
                <Book published=""true"">
                    <Title>Whispers in the Wind</Title>
                    <Price>12.99</Price>
                </Book>
                <Book published=""true"">
                    <Title>Moonlit Secrets</Title>
                    <Price>9.99</Price>
                </Book>
                <Book published=""true"">
                    <Title>The Last Orchard</Title>
                    <Price>24.99</Price>
                </Book>
                <Book published=""false"">
                    <Title>Shadows of Tomorrow</Title>
                    <Price>29.99</Price>
                </Book>
            </Books>
        ";

        public IActionResult Index()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlString);

            var titles = document.SelectNodes("/Books/Book[@published=\"true\"]/Title")
                                 .Cast<XmlNode>()
                                 .Select(node => node.InnerText)
                                 .ToList();

            ViewBag.BookTitles = titles;

            return View();
        }

        [HttpPost]
        public ContentResult FindBook([FromBody] BookSearch search)
        {
            if (search.Title.Contains("="))
            {
                return new ContentResult
                {
                    Content = "<Error>Invalid input.</Error>",
                    ContentType = "application/xml",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlString);

            var bookNode = document.SelectSingleNode("/Books/Book[Title='"+search.Title+"']");

            if (bookNode != null)
            {
                return new ContentResult
                {
                    Content = bookNode.OuterXml,
                    ContentType = "application/xml",
                    StatusCode = (int)HttpStatusCode.OK
                };
            }

            return new ContentResult
            {
                Content = "<Error>Book not found</Error>",
                ContentType = "application/xml",
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

    }

    public class BookSearch
    {
        public string Title { get; set; }
    }
}
