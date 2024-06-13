using CouponsV2.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponsV2.Data
{
    public class BaseContext(DbContextOptions<BaseContext> options) : DbContext(options)
    {

    }
}