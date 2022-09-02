﻿using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        =>_categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }
        [HttpGet()]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (!ModelState.IsValid) return View();
            await _categoryService.Add(categoryDto);
            return RedirectToAction(nameof(Index));             
        }
        [HttpGet()]
        public async Task<IActionResult>Edit(int id)
        {
            var categoryDto = await _categoryService.GetById(id);
            if (categoryDto is null) return NotFound();
            return View(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid) return View(categoryDTO);
            await _categoryService.Update(categoryDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
