using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TourismWeb.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }
        [ValidateNever]
        public User User { get; set; } 

        [Required]
        [Display(Name = "Địa điểm")] 
        public int SpotId { get; set; }
        [ValidateNever]
        public TouristSpot Spot { get; set; } 

        [Required]
        [MaxLength(50)]
        [RegularExpression("^(Địa điểm|Cẩm nang|Trải nghiệm|Bài viết)$", ErrorMessage = "Loại bài viết không hợp lệ.")] 
        public string TypeOfPost { get; set; } 

        [Required, MaxLength(100)]
        public string Title { get; set; } 

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string ImageUrl { get; set; } = "/images/default-postImage.png"; 
        public DateTime CreatedAt { get; set; } = DateTime.Now; 

        [Display(Name = "Trạng thái")] 
        public PostStatus Status { get; set; } = PostStatus.Pending; 

        // --- Thuộc tính MỚI cho Nội dung Động ---

        // == Cho Loại: "Địa điểm" ==
        [Display(Name = "Thời gian tham quan ước tính")]
        public string? EstimatedVisitTime { get; set; } 

        [Display(Name = "Thông tin giá vé")]
        public string? TicketPriceInfo { get; set; }   

        [Display(Name = "Điểm đánh giá (trên 5)")]
        [Range(0, 5)]
        public double? LocationRating { get; set; }     

        [Display(Name = "Lịch trình gợi ý")]
        public string? SuggestedItinerary { get; set; } // Có thể lưu HTML/Markdown đơn giản hoặc văn bản thuần

        // == Cho Loại: "Cẩm nang" ==
        [Display(Name = "Tóm tắt/Giới thiệu cẩm nang")]
        public string? GuidebookSummary { get; set; }

        [Display(Name = "Mẹo du lịch")]
        public string? TravelTips { get; set; }         // Lưu dưới dạng danh sách (HTML <ul><li>) hoặc Markdown

        [Display(Name = "Gợi ý đồ mang theo")]
        public string? PackingListSuggestions { get; set; } // Lưu dưới dạng văn bản/HTML/Markdown có cấu trúc

        [Display(Name = "Chi phí tham khảo")]
        public string? EstimatedCosts { get; set; }     // Lưu dưới dạng văn bản/HTML/Markdown có cấu trúc

        // Xem xét một thực thể liên quan riêng `DocumentLink` nếu bạn cần các liên kết có cấu trúc
        [Display(Name = "Tài liệu hữu ích (Links)")]
        public string? UsefulDocumentsHtml { get; set; } // Lưu dưới dạng thẻ HTML <a>

        // == Cho Loại: "Trải nghiệm" ==
        [Display(Name = "Ngày kết thúc trải nghiệm")]
        public DateTime? ExperienceEndDate { get; set; } 

        [Display(Name = "Người đồng hành")]
        public string? Companions { get; set; }         

        [Display(Name = "Chi phí ước tính")]
        public string? ApproximateCost { get; set; }   

        [Display(Name = "Đánh giá tổng quan (trên 10)")]
        [Range(0, 10)]
        public double? OverallExperienceRating { get; set; } 

        // Đối với đánh giá chi tiết, sử dụng các trường riêng biệt sẽ rõ ràng hơn là phân tích một chuỗi
        [Display(Name = "Điểm cảnh quan (trên 5)")]
        [Range(0, 5)]
        public double? RatingLandscape { get; set; }

        [Display(Name = "Điểm ẩm thực (trên 5)")]
        [Range(0, 5)]
        public double? RatingFood { get; set; }

        [Display(Name = "Điểm dịch vụ (trên 5)")]
        [Range(0, 5)]
        public double? RatingService { get; set; }

        [Display(Name = "Điểm giá cả (trên 5)")]
        [Range(0, 5)]
        public double? RatingPrice { get; set; }

        [Display(Name = "Những điểm nổi bật/Khoảnh khắc")]
        public string? ExperienceHighlights { get; set; } // Lưu dưới dạng danh sách (HTML <ul><li>) hoặc Markdown

        [Display(Name = "Tóm tắt hành trình")]
        public string? ExperienceItinerarySummary { get; set; } // Lưu dưới dạng văn bản/HTML/Markdown có cấu trúc

        [Display(Name = "Lời khuyên")]
        public string? Advice { get; set; }

        public ICollection<PostImage> Images { get; set; } = new List<PostImage>(); 
        public ICollection<PostFavorite> PostFavorites { get; set; } = new List<PostFavorite>(); 
        public ICollection<PostComment> Comments { get; set; } = new List<PostComment>(); 
        public ICollection<PostShare> Shares { get; set; } = new List<PostShare>(); 
    }

    public enum PostStatus
    {
        Pending, 
        Approved, 
        Rejected 
    }
}