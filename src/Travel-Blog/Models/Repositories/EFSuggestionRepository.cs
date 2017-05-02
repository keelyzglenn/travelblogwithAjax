using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

namespace TravelBlog.Models
{
    public class EFSuggestionRepository: ISuggestionRepository
    {
        TravelDbContext db = new TravelDbContext();

        public IQueryable<Suggestion> Suggestions
        { get { return db.Suggestions; } }

        public Suggestion Save(Suggestion suggestion)
        {
            db.Suggestions.Add(suggestion);
            db.SaveChanges();
            return suggestion;
        }
    
        public Suggestion Edit(Suggestion suggestion)
        {
            db.Entry(suggestion).State = EntityState.Modified;
            db.SaveChanges();
            return suggestion;
        }

        public void Remove(Suggestion suggestion)
        {
            db.Suggestions.Remove(suggestion);
            db.SaveChanges();
        }

        public EFSuggestionRepository(TravelDbContext connection = null)
        { 
            if (connection == null)
            {
                this.db = new TravelDbContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("delete from Suggestions");
        }

        public IEnumerable<Suggestion> Search(string newSearch)
        {
            return db.Suggestions.Where(x => x.Destination == newSearch).ToList();
        }

    }
}
