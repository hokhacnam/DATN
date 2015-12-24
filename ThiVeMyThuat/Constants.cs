using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiVeMyThuat
{
    class Constants
    {
        //msg content
        public const string Msg_Update_Success = "Cập nhật dữ liệu thành công";
        public const string Msg_Exception_Error = "Đã xảy ra lỗi ngoại lệ. Bạn có muốn xem chi tiết lỗi không?";
        public const string Msg_Confirm_Update = "Bạn có thật sự muốn cập nhật dữ liệu này?";
        public const string Msg_Mixing_Exam_first = "Vui lòng thực hiện trộn túi bài thi trước";
        public const string Msg_Backup_Success = "Tạo bản sao dữ liệu thành công";
        public const string Msg_Restore_Success = "Khôi phục dữ liệu thành công";
        public const string Msg_NOT_Existent_File = "KHÔNG tồn tại file vừa chọn";
        public const string Msg_Confirm_Restore_Data = "Bạn có chắc chắn khôi phục dữ liệu từ bản sao này không?";

        //msg caption
        public const string Msg_Caption_Error = "Thông báo lỗi";
        public const string Msg_Caption_Confirm = "Xác nhận";
        public const string Msg_Caption_Success = "Thông báo thành công";
        public const string Msg_Caption_Warning  = "Cảnh báo";
        public const string Msg_Caption_Exception_Error_Detail = "Chi tiết lỗi ngoại lệ";

        //URL
        public const string URL_Backup_Folder = @"\SQLBackup\";

        //ConnectDB
        public const string Conn_Name_in_AppConfig = "ThiVeMyThuat.Properties.Settings.XDAConnectionString";
    }
}
