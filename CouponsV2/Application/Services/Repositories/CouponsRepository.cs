using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CouponsV2.Dtos;
using CouponsV2.Models;
using CouponsV2.Infrastructure.Data;
using CouponsV2.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using CouponsV2.Application.Interfaces;
using CouponsV2.Application.Services.Emails;


namespace CouponsV2.Application.Services.Repositories
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CouponsRepository> _logger;

        private readonly IEmailRepository _emailRepository;

        public CouponsRepository(BaseContext context, IMapper mapper, ILogger<CouponsRepository> logger, IEmailRepository emailRepository)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _emailRepository = emailRepository;
        }

        public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
        {
            return await _context.Coupons.Include(c => c.MarketingUsers).ToListAsync();
        }
        public async Task<Coupon?> GetCouponByIdAsync(int id)
        {
            return await _context.Coupons.Include(m => m.MarketingUsers).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Coupon> CreateCouponAsync(CouponsDTO courseDTO)
        {
            if (courseDTO == null)
            {
                _logger.LogError("courseDTO is null");
                throw new ArgumentNullException(nameof(courseDTO));
            }

            // Validar propiedades requeridas
            if (string.IsNullOrEmpty(courseDTO.Name)) throw new ArgumentException("Name is required.");
            if (string.IsNullOrEmpty(courseDTO.Description)) throw new ArgumentException("Description is required.");
            if (string.IsNullOrEmpty(courseDTO.Code)) throw new ArgumentException("Code is required.");
            if (!courseDTO.Start_Date.HasValue) throw new ArgumentException("Start_Date is required.");
            if (!courseDTO.End_Date.HasValue) throw new ArgumentException("End_Date is required.");
            if (string.IsNullOrEmpty(courseDTO.Discount_Type)) throw new ArgumentException("Discount_Type is required.");
            if (!courseDTO.Discount_Value.HasValue) throw new ArgumentException("Discount_Value is required.");
            if (!courseDTO.Usage_Limit.HasValue) throw new ArgumentException("Usage_Limit is required.");
            if (!courseDTO.Min_Purchase_Amount.HasValue) throw new ArgumentException("Min_Purchase_Amount is required.");
            if (!courseDTO.Max_Purchase_Amount.HasValue) throw new ArgumentException("Max_Purchase_Amount is required.");
            if (string.IsNullOrEmpty(courseDTO.Status)) throw new ArgumentException("Status is required.");
            if (!courseDTO.Created_At.HasValue) throw new ArgumentException("Created_At is required.");
            if (!courseDTO.Created_By.HasValue) throw new ArgumentException("Created_By is required.");
            if (!courseDTO.Uses.HasValue) throw new ArgumentException("Uses is required.");

            var coupon = new Coupon
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                Code = courseDTO.Code,
                Start_Date = courseDTO.Start_Date,
                End_Date = courseDTO.End_Date,
                Discount_Type = courseDTO.Discount_Type,
                Discount_Value = courseDTO.Discount_Value,
                Usage_Limit = courseDTO.Usage_Limit,
                Min_Purchase_Amount = courseDTO.Min_Purchase_Amount,
                Max_Purchase_Amount = courseDTO.Max_Purchase_Amount,
                Status = courseDTO.Status,
                Created_By = courseDTO.Created_By,
                Created_At = courseDTO.Created_At,
                Uses = courseDTO.Uses
            };

            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }



        public async Task<Coupon>? UpdateCouponAsync(int id, CouponsDTO coupon)
        {

            var couponToUpdate = _context.Coupons.Find(id);
            _mapper.Map(coupon, couponToUpdate);
            _context.SaveChanges();
            return couponToUpdate;
        }

        public async Task<Coupon> DeleteCouponAsync(int id)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Id == id);
            if (coupon != null)
            {
                coupon.Status = "inactive";
                await _context.SaveChangesAsync();
            }
            return coupon;
        }

        public async Task<Coupon?> GetCouponsByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<Coupon?> RedemptionCouponAsync(string code)
        {
            if (code == null)
            {
                _logger.LogError("code is null");
                throw new ArgumentNullException(nameof(code));
            }

            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code);
            var now = DateTime.Now;
            if (coupon != null)
            {
                coupon.Status = "Used";
                coupon.Uses++;

                _context.Coupons.Update(coupon);
                await _context.SaveChangesAsync();

                var templateHtmlRoute = "Application/Utils/Resources/TemplatesHTML/index.html";

                // Reemplazar marcadores de posición con valores reales

                
                try
                {
                    string templateHtmlContent = System.IO.File.ReadAllText(templateHtmlRoute);
                         
                    // Reemplazar marcadores de posición con valores reales
                    var mensajeCustomer = templateHtmlContent
                        .Replace("{couponCode}", coupon.Code)
                        .Replace("{purchaseDate}", now.ToString("yyyy-MM-dd"));

                    
                    var subject = "Coupons - LuegoPago";
                    var emailCustomer = "kevindazar.dev@gmail.com";

                    await _emailRepository.SendEmailAsync(emailCustomer, subject, mensajeCustomer);
                }

                catch (Exception ex)
                {
                    // Manejar cualquier excepción que ocurra al leer el archivo
                    _logger.LogError($"Error al leer el archivo HTML: {ex.Message}");
                    throw; 
                }

           

                // var mensajeCustomer = $"Hola, Sr@ XXX,\nTu còdigo de Cupòn #{coupon.Code}, ha sido aplicado exitosamente a la compra realizada el XXX{now:yyyy-MM-dd}, por valor de $XXX,\n\n\n\n\nFeliz noche!";
                // var mensajeCustomer = templateHtmlContent;

           

                return coupon;

            }
            else
            {
                throw new KeyNotFoundException("Code not found or not valid");
            }
        }
    }
}
