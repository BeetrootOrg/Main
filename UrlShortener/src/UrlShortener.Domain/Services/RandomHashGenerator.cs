using System;
using System.Linq;
using UrlShortener.Domain.Services.Interfaces;

namespace UrlShortener.Domain.Services
{
    internal class RandomHashGenerator : IHashGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private readonly int _length;

        public RandomHashGenerator(int length)
        {
            _length = length;
        }
        
        public string ToHash(string original)
        {
            var random = new Random((int) DateTime.Now.Ticks);
            return new string(Enumerable.Repeat(Chars, _length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}