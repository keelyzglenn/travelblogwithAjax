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

    }
}
