﻿using Ardalis.Specification;
using CraftIQ.Inventory.Core.Entities.Categories;

namespace CraftIQ.Inventory.Core.Entities.Products.Specifications
{
    public class ReadProductsByCategoryIdSpecification : Specification<Category>
    {
        public ReadProductsByCategoryIdSpecification(Guid categoryId)
        {
            Query.Where(o => o._CategoryId == categoryId)
                 .Include(o => o.Products.Where(op => op.Category._CategoryId == categoryId));
        }
    }
}
