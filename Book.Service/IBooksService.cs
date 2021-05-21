using Book.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service
{
    public interface IBooksService
    {
        Task<IEnumerable<Books>> Get();
    }
}
