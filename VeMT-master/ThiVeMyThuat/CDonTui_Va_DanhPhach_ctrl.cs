using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiVeMyThuat
{
    class CDonTui_Va_DanhPhach_ctrl
    {
        public static void TronTuiBaiThi()
        {
            #region chặt nhỏ dữ liệu chia ra thành các phòng thi khác nhau

            //reset lst_tui và lst_phongthi
            Utils.lst_tui = new List<CTui>();
            Utils.lst_phongthi = new List<CPhongThi>();

            //lấy về dữ liệu
            dbVeMTDataContext db = new dbVeMTDataContext();
            //var db_sort = db.vemts.OrderBy(o => o.sobaodanh).OrderBy(o => o.phongthi);            

            int sophongthi = db.vemts.Select(o => o.phongthi).Distinct().Count(); //  30; //sau này cần lấy động số phòng thi.

            //loop so phong thi để chuẩn bị dữ liệu theo từng phòng thi
            for (int i = 0; i < sophongthi; i++)
            {
                //tạo ra đối tượng phòng thi 
                CPhongThi phongthi = new CPhongThi();

                //lấy về toàn bộ số thí sinh theo phòng thi thứ i+1.
                var lst_thisinh = db.vemts.Where(o => o.phongthi == i + 1);
                if (lst_thisinh.Count() > 0)
                {
                    //nếu số thí sinh trong 1 phòng thi  > 0 thì chuyển toàn bộ dữ liệu của thí sinh vào trong đối tượng phòng thi
                    foreach (var ts in lst_thisinh)
                    {
                        phongthi.Lst_baithi_theophong.Add(ts);
                    }
                }

                //add phòng thi vừa có vào lst phòng thi
                Utils.lst_phongthi.Add(phongthi);
            }
            //đến đây đã có toàn bộ dữ liệu về từng phòng thi.
            #endregion

            #region thực hiện trộn túi bài thi

            //tính số bài thi để chia đoạn phòng thi
            int chiadoan = Utils.sobaithi_theotui * 2 / 3 + 1;
            //tính có bao nhiêu túi bài thi cần trộn
            Utils.sotuibaithi = ((int)db.vemts.Count() / Utils.sobaithi_theotui) + 1;

            //khởi tạo đối tượng để random phòng thi cho mỗi lần lấy bài thi vào túi
            Random r = new Random();
            int k = r.Next(0, Utils.lst_phongthi.Count - 1);

            for (int i = 0; i < Utils.sotuibaithi; i++)
            {
                //khởi tạo 1 túi bài thi
                CTui tui = new CTui();
                tui.sobaithi_con_theotui = Utils.sobaithi_theotui;
                while (tui.sobaithi_con_theotui > 0 && Utils.lst_phongthi.Count() > 0)
                {
                    if (k > Utils.lst_phongthi.Count() - 1)
                    {
                        k = 0;
                    }
                    //MessageBox.Show(ar[index].ToString());

                    ////Ở đây chưa random nên lấy tuần tự
                    //for (int k = 0; k < lst_phongthi.Count(); k++)
                    //{

                    CPhongThi pt = Utils.lst_phongthi[k];

                    //kiểm tra xem phòng thi này còn bài thi k
                    pt.sobaithi_con_theophong = pt.Lst_baithi_theophong.Count();
                    if (pt.sobaithi_con_theophong > 0)
                    {
                        //nếu còn bài thi trong phòng thì kiểm tra xem nó có > phandoan k?
                        if (pt.sobaithi_con_theophong > chiadoan)
                        {
                            //Đ: kiểm tra số bài thi trong túi cần lấy thêm có > phandoan k?
                            if (tui.sobaithi_con_theotui > chiadoan)
                            {
                                //Đ: lấy tuần tự số <phandoan> bài từ phòng thi ném vào trong túi hiện tại
                                Move_record_from_pt_to_tui(tui, pt, chiadoan);
                                k = k + 1;
                            }
                            else
                            {
                                //S: lấy toàn bộ số bài thi còn trong phòng ném vào trong túi.
                                Move_record_from_pt_to_tui(tui, pt, tui.sobaithi_con_theotui);
                                //k = k + 1;
                            }

                            //update số bài thi còn
                            Update_sobaithi_con(tui, pt);
                        }
                        else
                        {
                            //S: kiểm tra số bài thi cần thêm vào túi có lớn hơn số bài thi còn trong phòng k
                            if (tui.sobaithi_con_theotui >= pt.sobaithi_con_theophong)
                            {
                                //Đ: lấy hết số bài thi còn trong phòng
                                Move_record_from_pt_to_tui(tui, pt, pt.sobaithi_con_theophong);
                                //k = k + 1;

                            }
                            else
                            {
                                /********************************************************/
                                #region summary: đoạn này để chống phân mảnh bài thi.
                                //----------------------------------------------------------------

                                //S: kiểm tra số phòng thi còn trong lst_phongthi >2 hay không
                                //if (lst_phongthi.Count() > 2)
                                //{
                                //    //Đ: kiểm tra số lượng bài thi còn dư lại nếu lấy = số bài thi cần thêm vào túi
                                //    int sobaithi_con_saukhi_laydu_theotui = pt.sobaithi_con_theophong - tui.sobaithi_con_theotui;
                                //    if (sobaithi_con_saukhi_laydu_theotui > 3)
                                //    {
                                //        //Đ: Lấy = số bài thi cần thêm vào túi.
                                //        Move_record_from_pt_to_tui(tui, pt, tui.sobaithi_con_theotui);
                                //    }
                                //}
                                //else
                                //{
                                //------------------------------------------------------------------------
                                #endregion
                                /********************************************************/
                                //S: Lấy = số bài thi cần thêm vào túi.
                                Move_record_from_pt_to_tui(tui, pt, tui.sobaithi_con_theotui);
                                //}


                            }

                            //update số bài thi còn
                            Update_sobaithi_con(tui, pt);
                        }
                    }
                    else
                    {
                        //nếu phòng thi này k còn bài thi nào -> loại ra khỏi list_phongthi
                        Utils.lst_phongthi.Remove(pt);
                    }

                    //nếu đã lấy đủ số bài thi cho túi thì break loop.
                    if (tui.sobaithi_con_theotui == 0)
                    {
                        break;
                    }
                }

                //}

                //sau khi chèn đủ số bài thi vào túi -> add vào list_tui
                Utils.lst_tui.Add(tui);
            }
            #endregion

            #region đánh số túi cho từng túi bài thi
            Danh_matui();
            #endregion

        }

        private static void Update_sobaithi_con(CTui tui, CPhongThi pt)
        {
            //update lại số bài thi trong túi
            tui.sobaithi_con_theotui = Utils.sobaithi_theotui - tui.Lst_baithi_theotui.Count();
            //update lại số bài thi trong phòng
            pt.sobaithi_con_theophong = pt.Lst_baithi_theophong.Count();
        }

        private static void Move_record_from_pt_to_tui(CTui tui, CPhongThi pt, int num_loop)
        {
            for (int j = 0; j < num_loop; j++)
            {
                tui.Lst_baithi_theotui.Add(pt.Lst_baithi_theophong[0]);
                pt.Lst_baithi_theophong.RemoveAt(0);
            }
        }

        private static void Danh_matui()
        {
            //khởi tạo đối tượng để random mã túi
            Random r = new Random();

            //khởi tạo mảng các số từ 0 đến lst_tui.count -1 để lấy random k bị lặp lại.
            List<int> arr = new List<int>();
            for (int i = 0; i < Utils.lst_tui.Count; i++)
            {
                arr.Add(i);
            }

            //gán mã túi và stt túi cho từng túi
            for (int i = 0; i < Utils.lst_tui.Count(); i++)
            {
                //lấy ngẫu nhiên mã túi ( k )
                int index = r.Next(0, arr.Count - 1); //biến lấy ra 1 chỉ số ngẫu nhiên trong số phần tử của arr
                int k = arr[index]; //lấy ra giá trị của phần tử tương ứng trong arr, cũng là mã túi tương ứng.
                arr.RemoveAt(index); //sau khi lấy ra -> xóa ngay phần tử vừa lấy của arr để tránh việc lặp lại mã túi.

                for (int j = 0; j < Utils.lst_tui[i].Lst_baithi_theotui.Count(); j++)
                {
                    //gán mã túi
                    Utils.lst_tui[i].Lst_baithi_theotui[j].tui = k + 1;
                    //gán số thứ tự theo từng túi
                    Utils.lst_tui[i].Lst_baithi_theotui[j].stttui = j + 1;
                }
            }

            //sắp xếp lại lst_tui tuần tự theo mã túi
            Utils.lst_tui = Utils.lst_tui.OrderBy(o => o.Lst_baithi_theotui[0].tui).ToList();

            //gán số phách cho bài thi tuần tự theo mã túi.
            for (int i = 0; i < Utils.lst_tui.Count(); i++)
            {
                for (int j = 0; j < Utils.lst_tui[i].Lst_baithi_theotui.Count(); j++)
                {
                    //gán số phách cho từng bài thi
                    Utils.lst_tui[i].Lst_baithi_theotui[j].phach = i * Utils.sobaithi_theotui + j + 1;
                }
            }
        }

        public static void Update_DB()
        {
            try
            {
                dbVeMTDataContext db = new dbVeMTDataContext();

                foreach (CTui tui in Utils.lst_tui)
                {
                    foreach (vemt rc in tui.Lst_baithi_theotui)
                    {
                        //cần validate dữ liệu ở đây k?

                        //lấy về đối tượng tương ứng
                        var rc_in_DB = db.vemts.Where(o => o.sobaodanh == rc.sobaodanh).Single();
                        rc_in_DB.tui = rc.tui;
                        rc_in_DB.stttui = rc.stttui;
                        rc_in_DB.phach = rc.phach;
                    }
                }

                db.SubmitChanges();

                MessageBox.Show(Constants.Msg_Update_Success, Constants.Msg_Caption_Success, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                Utils.Show_Exception_Msg(ex);
            }
        }
    }
}
