﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        [Route("EventCategory/Create")]
        public IActionResult Create()
        {
            AddEventCategoryViewModels addEventCategoryViewModels = new AddEventCategoryViewModels();

            return View();
        }

        [HttpPost]
        [Route("EventCategory/CreateForm")]

        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModels addEventCategoryViewModels)
        {
            if(ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModels.Name,
                };

                context.Categories.Add(newEventCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View("Create", addEventCategoryViewModels);
        }
    }
}
