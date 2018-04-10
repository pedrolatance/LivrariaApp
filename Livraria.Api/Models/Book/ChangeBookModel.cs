﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Api.Models
{
    public class ChangeBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int StorageQty { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
    }
}