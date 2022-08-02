using HtmlAgilityPack;
using SearchEngine.Common.DTOs;

List<BrowserDto> browserDtos = new List<BrowserDto>();
HtmlWeb web = new();
HtmlDocument document = web.Load("https://biblprog.org.ua/ru/browsers/");

var title = document.DocumentNode.SelectNodes("/html/body/div/div/div[1]/div/div/table/tbody/tr[1]/td/div/div[2]/div/h4/a").First().InnerText;
browserDtos.Add(new BrowserDto { Name = title });
   