﻿using NTierProject1B.DATAACCESS.Context;
using NTierProject1B.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject1B.DATAACCESS.Repositories.Concrete
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
