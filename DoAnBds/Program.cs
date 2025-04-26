
using DoAnBds.Models;
using DoAnBds.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
//cHUỖI KẾT NỐI VỚI DB
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddScoped<BatDongSanService, BatDongSanServiceImpl>();
builder.Services.AddScoped<DanhMucBatDongSanService, DanhMucBatDongSanSeriveImpl>();
builder.Services.AddScoped<NhanVienService, NhanVienServiceImpl>();
builder.Services.AddScoped<BaiVietService, BaiVietServiceImpl>();
builder.Services.AddScoped<FormService, FormServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<KhachHangService, KhachHangServiceImpl>();
builder.Services.AddScoped<NhaThauService, NhaThauServiceImpl>();
builder.Services.AddScoped<PhanQuyenService, PhanQuyenServiceImpl>();
builder.Services.AddScoped<BoPhanService, BoPhanServiceImpl>();
var app = builder.Build();
app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");
app.Run();
