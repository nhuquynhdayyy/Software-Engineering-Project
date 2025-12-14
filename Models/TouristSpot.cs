using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TourismWeb.Models
{
    public class TouristSpot
    {
        [Key]
        public int SpotId { get; set; }

        [Required(ErrorMessage = "Tên địa điểm không được để trống.")]
        [MaxLength(100, ErrorMessage = "Tên địa điểm không được vượt quá 100 ký tự.")]
        [Display(Name = "Tên địa điểm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        [ForeignKey("Category")]
        [Display(Name = "Danh mục")]
        public int? CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

        [Display(Name = "Mô tả")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; } = "/images/default-spotImage.png"; 

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required] 
        public int CreatorUserId { get; set; } 

        [ForeignKey("CreatorUserId")]
        [ValidateNever]
        public virtual User CreatorUser { get; set; } 

        // Thuộc tính này nên được xác định ở Controller dựa trên User hiện tại và Favorites
        [NotMapped] // Không lưu vào DB trực tiếp, mà tính toán khi cần
        public bool IsLikedByCurrentUser { get; set; } = false;


        // --- CÁC TRƯỜNG MỚI ĐỂ LƯU DỮ LIỆU ĐỘNG ---
        [Display(Name = "Thời gian tham quan lý tưởng")]
        public string IdealVisitTime { get; set; } 

        [Display(Name = "Các dịch vụ có sẵn")]
        public string AvailableServices { get; set; } 

        [Display(Name = "Mẹo du lịch")]
        [DataType(DataType.MultilineText)]
        public string TravelTips { get; set; } // Lưu các mẹo, mỗi mẹo một dòng hoặc phân cách bằng ký tự đặc biệt

        [Display(Name = "URL nhúng bản đồ")]
        [DataType(DataType.Url)]
        public string MapEmbedUrl { get; set; } // Lưu URL src của iframe Google Maps

        [Display(Name = "URL nhúng video")]
        [DataType(DataType.Url)]
        public string VideoEmbedUrl { get; set; } // Lưu URL src của iframe YouTube (hoặc chỉ ID video nếu bạn muốn xử lý linh hoạt hơn)

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<SpotFavorite> Favorites { get; set; } = new List<SpotFavorite>();
        public ICollection<SpotShare> Shares { get; set; } = new List<SpotShare>();
        public ICollection<SpotImage> Images { get; set; } = new List<SpotImage>();
        public ICollection<Post> Posts { get; set; } = new List<Post>(); // Dùng cho "Cẩm nang du lịch"
    }
}