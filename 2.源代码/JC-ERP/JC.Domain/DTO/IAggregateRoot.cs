using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC.Domain.DTO
{
    public interface IAggregateRoot
    {
    }

    public class Summary<T> where T : class, IAggregateRoot
    {
        public IList<T> List { get; set; }

        public int Total { get; set; }
    }
}
