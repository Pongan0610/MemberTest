using MemberTest.Models.EFModels;
using MemberTest.Models.ViewModels.Home;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MemberTest.Models.LogicModels
{
    public class MemberLogic
    {
        /// <summary>
        /// 取得成員資料
        /// </summary>
        /// <returns></returns>
        public List<Member> GetMemberList()
        {
            List<Member> result = new List<Member>();
            using (var context = new TestContext())
            {
                result = context.Members.ToList();
            }
            return result;
        }

        /// <summary>
        /// 依編號取會員資料
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public Member? GetMember(int sn)
        {
            var member = new Member();
            using (var context = new TestContext())
            {
                member = context.Members.Where(w => w.Sn == sn).FirstOrDefault();
            }
            return member;
        }

        /// <summary>
        /// 新增成員資料
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool AddMember(Member member)
        {
            
            try
            {
                using (var context = new TestContext())
                {
                    context.Members.Add(member);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 更新成員資料
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool UpdateMember(Member member)
        {
            try
            {
                using (var context = new TestContext())
                {
                    context.Members.Update(member);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 刪除成員資料
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public bool DeleteMember(int sn)
        {
            try
            {
                using (var context = new TestContext())
                {
                    var member = context.Members.Where(w => w.Sn == sn).FirstOrDefault();
                    if (member != null)
                    {
                        context.Members.Remove(member);
                        context.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 驗證資料正確性
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public MemberViewModel IsValid(MemberViewModel member)
        {
            List<string> errorLs = new List<string>();
            if (member.Phone != null && !Regex.IsMatch(member.Phone, @"^09[0-9]{8}$")) // 手機
            {
                errorLs.Add("手機格式不正確");
                member.IsVaild = false;
            }

            if (member.Mail != null) // email
            {
                try
                {
                    MailAddress m = new MailAddress(member.Mail);
                }
                catch (FormatException)
                {
                    member.IsVaild = false;
                    errorLs.Add("郵件格式不正確");
                }
            }

            if (errorLs.Count > 0)
            {
                member.Msg = string.Join(",", errorLs);
            }

            return member;
        }
    }
}
