using MemberTest.Models.EFModels;

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
                    context.Entry<Member>(member).Property(x => x.Sn).IsModified = false; // 忽略SN欄位
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
    }
}
