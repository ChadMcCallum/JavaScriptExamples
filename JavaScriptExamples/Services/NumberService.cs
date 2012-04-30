using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Nancy;

namespace JavaScriptExamples
{
    public class NumberService : NancyModule
    {
        Random _random;

        public NumberService() : base("/Services")
        {
            _random = new Random();

            Get["/numbers"] = x => GetRandomNumbers();
            Post["/numbers"] = x => CreateNumber();
            Put["/numbers/{number}"] = x => SaveNumber(x.number);
            Delete["/numbers/{number}"] = x => DeleteNumber(x.number);
        }

        private Response CreateNumber()
        {
            return Response.AsJson(new Number { id = _random.Next(), Value = _random.Next() });
        }

        private Response DeleteNumber(int number)
        {
            return Response.AsJson(new Number());
        }

        private Response SaveNumber(int number)
        {
            return Response.AsJson(new Number { id = number, Value = _random.Next() });
        }

        private Response GetRandomNumbers()
        {
            var numbers = new List<Number>();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(new Number { id = _random.Next(), Value = _random.Next() });
            }
            return Response.AsJson(numbers);
        }
    }

    public class Number
    {
        public int id { get; set; }
        public int Value { get; set; }
    }
}