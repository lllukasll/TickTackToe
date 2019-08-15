using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe.Shared.Dto.Common
{
    public class Response
    {
        public Response()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public object Data { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public bool ErrorOccurred => Errors.Count > 0;

        public void AddError(string field, string message)
        {
            if (Errors.ContainsKey(field))
            {
                Errors[field].Add(message);
            }
            else
            {
                Errors.Add(field, new List<string>() { message });
            }
        }
    }
}
