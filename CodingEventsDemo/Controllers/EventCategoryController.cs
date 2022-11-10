﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        [Route("/EventCategory/Create")]
        public IActionResult Create()
        {
            AddEventCategoryViewModel model1 = new AddEventCategoryViewModel();
            return View(model1);
        }

        [HttpPost]
        [Route("/EventCategory")]
        public IActionResult Add(AddEventCategoryViewModel model2)
        {
            if (ModelState.IsValid)
            {
                EventCategory newCategory = new EventCategory
                {
                    Name = model2.Name,
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();
                return Redirect("/EventCategory");
            }

            return View("/EventCategory/Create", model2);
        }
    }
}

