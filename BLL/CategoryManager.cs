using BLL.Base;
using BLL.Contracts;
using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class CategoryManager:Manager<Category>, ICategoryManager
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository CategoryRepository) : base(CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }

    }
}
