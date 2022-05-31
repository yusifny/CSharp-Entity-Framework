using System;
using System.Collections.Generic;
using System.Linq;
using CSharp_Entity_Framework.DAL;
using CSharp_Entity_Framework.Exceptions;
using CSharp_Entity_Framework.Models;

namespace CSharp_Entity_Framework
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            
        }
        static void AddPost(Post post)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }
        }

        static void GetAllPosts()
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                List<Post> posts = dbContext.Posts.ToList();
                foreach (var item in posts)
                {
                    Console.WriteLine($"Id: {item.Id}\nTittle: {item.Title}\nContent: {item.Content}\nImage: {item.Image}");
                }

            }
        }
        static void DeletePostById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id cannot be blank");

            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post dbPost = dbContext.Posts.FirstOrDefault(p => p.Id == id);
                if (dbPost == null)
                {
                    throw new NotFoundException("Post is not found");

                }

                dbContext.Posts.Remove(dbPost);

                Console.WriteLine($"{id} deleted");
                dbContext.SaveChanges();
            }

        }
        static void GetPostById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id cannot be blank");
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post dbPost = dbContext.Posts.FirstOrDefault(x => x.Id == id);
                if (dbPost == null)
                {
                    throw new NotFoundException("Post is not found");
                }
                Console.WriteLine($"Id: {dbPost.Id}\nTitle: {dbPost.Title}\nContent: {dbPost.Content}\nImage: {dbPost.Image}");
            }
        }
        static void EditPostTitle(int? id, string tittle)
        {
            if (id == null)
            {
                Console.WriteLine("Id cannot be blank");
                return;
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post dbPost = dbContext.Posts.Find(id, tittle);
                if (id == null)
                {
                    Console.WriteLine($"{id} not found ");
                    return;
                }
                dbPost.Title = $"Edited Title{tittle}";
                Console.WriteLine($"{id}. Post Edited");
                dbContext.SaveChanges();

            }
        }
    }
}