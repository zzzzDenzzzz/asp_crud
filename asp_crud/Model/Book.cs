﻿namespace asp_crud.Model
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Author { get; set; }

        public string? Description { get; set; }

        public int PageCount { get; set; }

        public string? Genre { get; set; }
    }
}
