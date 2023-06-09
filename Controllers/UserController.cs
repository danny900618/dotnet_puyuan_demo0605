using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using PuYuan_net7.Models;
using PuYuan_net7.Models;
using PuYuan_net7.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Data.SqlClient;

namespace PuYuan_net7.Controllers
{
    [Authorize] //需要授權才能使用
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PuYuanContext _context;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(PuYuanContext context, UserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        // PATCH: api/user
        /// <summary>
        /// 7.個人資訊設定
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<ActionResult> PatchUser(UserInfoViewModel userSet)
        {
            var patchFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return patchFail;
            }

            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            if (user == null)
            {
                return patchFail;
            }
            user = _mapper.Map(userSet, user);
            //foreach (var propertyInfo in userSet.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            //{
            //    var value = propertyInfo.GetValue(userSet);

            //    if (value != null)
            //    {
            //        var property = typeof(User).GetProperty(propertyInfo.Name);
            //        property.SetValue(user, value, null);
            //    }

            //}
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return patchFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // PATCH: api/user/default
        /// <summary>
        /// 11.個人預設值
        /// </summary>
        /// <returns></returns>
        [HttpPatch("default")]
        public async Task<ActionResult> PatchUserDefult(UserSetViewModel userSet)
        {
            var patchFail = new JsonResult(new { status = 1 });
            if (_context.UserSet == null)
            {
                return patchFail;
            }

            //var user = _context.UserSet.Single(b => b.Account == User.Identity.Name);
            var user = _context.UserSet.Single(b => b.Account == User.Identity.Name);
            if (user == null)
            {
                return patchFail;
            }

            foreach (var propertyInfo in userSet.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userSet);

                if (value != null)
                {
                    var property = typeof(UserSet).GetProperty(propertyInfo.Name);
                    property.SetValue(user, value, null);
                }

            }
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return patchFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // PATCH: api/user/setting
        /// <summary>
        /// 35.個人設定
        /// </summary>
        /// <returns></returns>
        [HttpPatch("setting")]
        public async Task<ActionResult> PatchUserSetting(UserSettingViewModel userSet)
        {
            var patchFail = new JsonResult(new { status = 1 });
            if (_context.UserSet == null)
            {
                return patchFail;
            }

            var user = _context.UserSet.Single(b => b.Account == User.Identity.Name);
            if (user == null)
            {
                return patchFail;
            }

            foreach (var propertyInfo in userSet.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userSet);

                if (value != null)
                {
                    var property = typeof(UserSet).GetProperty(propertyInfo.Name);
                    property.SetValue(user, value, null);
                }

            }
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return patchFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // POST: api/user/blood/pressure
        /// <summary>
        /// 8.上傳血壓測量結果
        /// </summary>
        /// <returns></returns>
        [HttpPost("blood/pressure")]
        public async Task<ActionResult<BloodPressure>> PostUserBlood_p(UserBloodPViewModel userBlood)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var userBP = new BloodPressure();

            foreach (var propertyInfo in userBlood.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userBlood);

                if (value != null)
                {
                    var property = typeof(BloodPressure).GetProperty(propertyInfo.Name);
                    property.SetValue(userBP, value, null);
                }
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            userBP.Uid = user.Uid;
            try
            {
                _context.BloodPressure.Add(userBP);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return postFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // POST: api/user/weight
        /// <summary>
        /// 9.上傳體重測量結果
        /// </summary>
        /// <returns></returns>
        [HttpPost("weight")]
        public async Task<ActionResult<Weight_M>> PostUserWeight(UserWeightViewModel userWeight)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var userW = new Weight_M();

            foreach (var propertyInfo in userWeight.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userWeight);

                if (value != null)
                {
                    var property = typeof(Weight_M).GetProperty(propertyInfo.Name);
                    property.SetValue(userW, value, null);
                }
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            userW.Uid = user.Uid;
            try
            {
                _context.Weight.Add(userW);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return postFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // POST: api/user/blood/sugar
        /// <summary>
        /// 10.上傳血糖
        /// </summary>
        /// <returns></returns>
        [HttpPost("blood/sugar")]
        public async Task<ActionResult<BloodSugar>> PostUserBlood_s(UserBloodSugarViewModel userBloodS)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var userBS = new BloodSugar();

            foreach (var propertyInfo in userBloodS.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userBloodS);

                if (value != null)
                {
                    var property = typeof(BloodSugar).GetProperty(propertyInfo.Name);
                    property.SetValue(userBS, value, null);
                }
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            userBS.Uid = user.Uid;
            try
            {
                //C
                //await _context.SaveChangesAsync();
            }
            catch
            {
                return postFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // POST: api/user/care
        /// <summary>
        /// 28. 發送關懷諮詢
        /// </summary>
        /// <returns></returns>
        [HttpPost("care")]
        public async Task<ActionResult> PostUserCare(UserCareViewModel userCare)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            if (user == null)
            {
                return postFail;
            }
            user.Message = userCare.Message;
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // POST: api/user/a1c
        /// <summary>
        /// 33.送糖化血色素
        /// </summary>
        /// <returns></returns>
        [HttpPost("a1c")]
        public async Task<ActionResult<A1c>> PostUserA1c(UserA1cViewModel userA1c)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var a1c = new A1c();

            foreach (var propertyInfo in userA1c.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userA1c);

                if (value != null)
                {
                    var property = typeof(A1c).GetProperty(propertyInfo.Name);
                    property.SetValue(a1c, value, null);
                }
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            a1c.Uid = user.Uid;
            try
            {
                _context.A1c.Add(a1c);
                _context.SaveChangesAsync();
            }
            catch
            {
                return postFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // DELETE: api/user/a1c
        /// <summary>
        /// 34.刪除糖化血色素
        /// </summary>
        /// <returns></returns>
        [HttpDelete("a1c")]
        public async Task<ActionResult> DeleteUserA1c()
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            if (user == null)
            {
                return postFail;
            }
            var a1c = _context.A1c.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();
            _context.A1c.Remove(a1c);
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // PATCH: api/user/medical
        /// <summary>
        /// 31. 更新就醫資訊
        /// </summary>
        /// <returns></returns>
        [HttpPatch("medical")]
        public async Task<ActionResult> PatchUserMedical(UserMedicalViewModel userMedical)
        {
            var patchFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return patchFail;
            }

            var me = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.Medical.Single(x => x.Uid == me.Uid);
            if (user == null)
            {
                return patchFail;
            }

            foreach (var propertyInfo in userMedical.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userMedical);

                if (value != null)
                {
                    var property = typeof(Medical).GetProperty(propertyInfo.Name);
                    property.SetValue(user, value, null);
                }

            }
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return patchFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // POST: api/user/drug-used
        /// <summary>
        /// 42.上傳藥物資訊
        /// </summary>
        /// <returns></returns>
        [HttpPost("drug-used")]
        public async Task<ActionResult<Medical>> PostUserDrugUsed(UserDrugUsedPostViewModel userDrugUsed)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var medical = new Medical();

            foreach (var propertyInfo in userDrugUsed.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userDrugUsed);

                if (value != null)
                {
                    var property = typeof(Medical).GetProperty(propertyInfo.Name);
                    property.SetValue(medical, value, null);
                }
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            medical.Uid = user.Uid; 
            try
            {
                _context.Medical.Add(medical);
                _context.SaveChangesAsync();
            }
            catch
            {
                return postFail;
            }
            return new JsonResult(new { status = 0 });
        }


        // DELETE: api/user/drug-used
        /// <summary>
        /// 43.刪除藥物資訊
        /// </summary>
        /// <returns></returns>
        [HttpDelete("drug-used")]
        public async Task<ActionResult> DeleteUserDrugUsed()
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }
            var me = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.Medical.Where(x => x.Uid == me.Uid).OrderBy(x => x.ID).LastOrDefault();
            if (user == null)
            {
                return postFail;
            }
            _context.Medical.Remove(user);
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }
        // POST: api/user/diet
        /// <summary>
        /// 15.飲食日記
        /// </summary>
        /// <returns></returns>
        [HttpPost("diet")]
        public async Task<ActionResult<Diary>> PostUserDiary(UserDiaryViewModel userDiary)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var diary = new Diary();

            foreach (var propertyInfo in userDiary.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userDiary);

                if (value != null)
                {
                    var property = typeof(Diary).GetProperty(propertyInfo.Name);
                    property.SetValue(diary, value, null);
                }
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            diary.Uid = user.Uid;
            try
            {
                _context.Diary.Add(diary);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return postFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // GET: api/user/last-upload
        /// <summary>
        /// 25. 最後上傳時間
        /// </summary>
        /// <returns></returns>
        [HttpGet("last-upload")]
        public async Task<UserLastUploadModel> GetLastUpload()
        {
            //UserLastUploadModel lastupload = null;
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            var BP = _context.BloodPressure.Where(x => x.Uid == user.Uid ).OrderBy(x => x.ID).LastOrDefault();
            var W = _context.Weight.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();
            var BS = _context.BloodSugar.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();

            var lastupload = new UserLastUploadModel
            {
                Status = "0",
                Last_upload = new LastUploadValue
                {
                    Blood_pressure = BP.Pulse,
                    Weight = W.Weight,
                    Blood_sugar = BS.Sugar,
                    Diet = W.Recorded_at
                }
            };
            return lastupload;
        }


        // GET: api/user/a1c
        /// <summary>
        /// 32.糖化血色素
        /// </summary>
        /// <returns></returns>
        [HttpGet("a1c")]
        public async Task<userA1cValue> GetUserA1c()
        {
            //UserLastUploadModel lastupload = null;
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            var A1c_DB = _context.A1c.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).ToArray();
            List<A1csValue> A1csList = new List<A1csValue>();
            foreach (var data in A1c_DB)
            {
                A1csValue a = new A1csValue()
                {
                    Id = data.ID,
                    User_id = data.ID,
                    A1c_v = data.A1c_v,
                    Recorded_at = data.Recorded_at,
                    Created_at = data.Recorded_at,
                    Updated_at = data.Recorded_at,
                };
                A1csList.Add(a);
            }
            var a1c = new userA1cValue
            {
                Status = "0",
                A1cs = A1csList
            };
            return a1c;
        }

        // GET: api/user/drug-used
        /// <summary>
        /// 41.藥物資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet("drug-used")]
        public async Task<userDrugUsedValue> GetDrugUsed()
        {
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            var A1c_DB = _context.Medical.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).ToArray();
            List<DrugValue> A1csList = new List<DrugValue>();
            foreach (var data in A1c_DB)
            {
                DrugValue a = new DrugValue()
                {
                    Id = data.ID,
                    User_id = data.ID,
                    Drugtype = data.Drugtype,
                    Drugname = data.Drugname,
                    Recorded_at = data.Recorded_at
                };
                A1csList.Add(a);
            }
            var a1c = new userDrugUsedValue
            {
                Status = "0",
                Drug_useds = A1csList
            };
            return a1c;
        }
        // POST: api/user/records
        /// <summary>
        /// 44.上一筆紀錄資訊
        /// </summary>
        /// <returns></returns>
        [HttpPost("records")]
        public async Task<RecordsValue> PostRecords(RecordsViewModel records)
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var BP = _context.BloodPressure.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();
                var W = _context.Weight.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();
                var BS = _context.BloodSugar.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();

                var record = new RecordsValue
                {
                    Status = "0",
                    Blood_sugars = new RecordsBloodSugarValue
                    {
                        Sugar = BS.Sugar,
                        Exercise = 0,
                        Drug = 0,
                        Timeperiod = BS.timeperiod,
                        Recorded_at = BS.Recorded_at

                    },
                    Blood_pressures = new RecordsBloodPressuresValue
                    {
                        Systolic = BP.Systolic,
                        Diastolic = BP.Diastolic,
                        Pulse = BP.Pulse,
                        Recorded_at = BP.Recorded_at
                    },
                    Weights = new RecordsWeightsValue
                    {
                        Weight = W.Weight,
                        Body_fat = W.Body_fat,
                        Bmi = W.Bmi,
                        Recorded_at = BP.Recorded_at
                    }

                };
                return record;
            }
            catch
            {
                var record = new RecordsValue
                {
                    Status = "1"
                };
                return record;
            }
        }

        // DELETE: api/user/records
        /// <summary>
        /// 40.刪除日記記錄
        /// </summary>
        /// <returns></returns>
        [HttpDelete("records")]
        public async Task<ActionResult> DeleteUserRecords(DeleteUserRecordsViewModel userRecords)
        {
            var deleteFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return deleteFail;
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            var BP = _context.BloodPressure.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();
            var W = _context.Weight.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();
            var BS = _context.BloodSugar.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).LastOrDefault();

            if (user == null)
            {
                return deleteFail;
            }
            _context.BloodPressure.Remove(BP);
            _context.Weight.Remove(W);
            _context.BloodSugar.Remove(BS);
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // GET: api/user
        /// <summary>
        /// 12.個人資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<userValue>> GetUser()
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var weight = _context.Weight.Single(x => x.Uid == user.Uid);
                var userSet = _context.UserSet.Single(x => x.Uid == user.Uid);

                var result = new userValue
                {
                    Status = "0",
                    User = new UserInfoValue
                    {
                        Id = 1,
                        Account = user.Account,
                        Email = user.Email,
                        Phone = user.Phone,
                        Fb_id = "1",
                        Satus = "1",
                        Group = "1",
                        Birthday = user.Birthday,
                        Height = user.Height,
                        Weight = weight.Weight,
                        Gender = user.Gender,
                        Address = user.Address,
                        Unread_records = new[] { "0", "0", "0" },
                        Verified = true,
                        Privacy_policy = true,
                        Must_change_password = true,
                        Fcm_id = user.Fcm_id,
                        Badge = 87,
                        Login_times = 0,
                        Created_at = weight.Recorded_at,
                        Updated_at = weight.Recorded_at,
                        Default = new UserInfoDefaultValue
                        {
                            Id = 1,
                            User_id = 1,
                            Sugar_delta_max = userSet.Sugar_delta_max,
                            Sugar_delta_min = userSet.Sugar_delta_min,
                            Sugar_morning_max = userSet.Sugar_morning_max,
                            Sugar_morning_min = userSet.Sugar_morning_min,
                            Sugar_evening_max = userSet.Sugar_evening_max,
                            Sugar_evening_min = userSet.Sugar_evening_min,
                            Sugar_before_max = userSet.Sugar_before_max,
                            Sugar_before_min = userSet.Sugar_before_min,
                            Sugar_after_max = userSet.Sugar_after_max,
                            Sugar_after_min = userSet.Sugar_after_min,
                            Systolic_max = userSet.Systolic_max,
                            Systolic_min = userSet.Systolic_min,
                            Diastolic_max = userSet.Diastolic_max,
                            Diastolic_min = userSet.Diastolic_min,
                            Pulse_max = userSet.Pulse_max,
                            Pulse_min = userSet.Pulse_min,
                            Weight_max = userSet.Weight_max,
                            Weight_min = userSet.Weight_min,
                            Bmi_max = userSet.Bmi_max,
                            Bmi_min = userSet.Bmi_min,
                            Body_fat_max = userSet.Body_fat_max,
                            Body_fat_min = userSet.body_fat_min,
                            Created_at = weight.Recorded_at,
                            Updated_at = weight.Recorded_at,
                        },
                        Setting = new UserInfoSettingValue
                        {
                            Id = 1,
                            User_id = 1,
                            After_recording = userSet.After_recording,
                            No_recording_for_a_day = userSet.No_recording_for_a_day,
                            Over_max_or_under_min = userSet.Over_max_or_under_min,
                            After_meal = userSet.After_meal,
                            Unit_of_sugar = userSet.Unit_of_sugar,
                            Unit_of_weight = userSet.Unit_of_weight,
                            Unit_of_height = userSet.Unit_of_height,
                            Created_at = weight.Recorded_at,
                            Updated_at = weight.Recorded_at
                        }
                    }
                };
                return result;
            }
            catch
            {
                var result = new userValue
                {
                    Status = "1"
                };
                return result;
            }
        }

        // GET: api/user/medical
        /// <summary>
        /// 30. 就醫資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet("medical")]
        public async Task<userMedicalInfoValue> GetMedical()
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var medical = _context.Medical.Single(x => x.Uid == user.Uid);

                var result = new userMedicalInfoValue
                {
                    Status = "0",
                    Medical_info = new MedicalValue
                    {
                        Id = medical.ID,
                        User_id = medical.ID,
                        Diabetes_type = medical.Diabetes_type,
                        Oad = medical.Oad,
                        Insulin = medical.Oad,
                        Anti_hypertensives = medical.Anti_hypertensives,
                        Created_at = medical.Recorded_at,
                        Updated_at = medical.Recorded_at
                    }
                };
                return result;
            }
            catch
            {
                var result = new userMedicalInfoValue
                {
                    Status = "1"
                };
                return result;
            }
        }

        // GET: api/user/care
        /// <summary>
        /// 27. 獲取關懷諮詢
        /// </summary>
        /// <returns></returns>
        [HttpGet("care")]
        public async Task<userCareValue> GetUserCare()
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var allUser = _context.User.Where(x => x.Uid != null).OrderBy(x => x.ID).ToArray();
                List<CareValue> cares = new List<CareValue>();
                foreach (var userInfo in allUser)
                {
                    CareValue a = new CareValue()
                    {
                        Id = userInfo.ID,
                        User_id = userInfo.ID,
                        member_id = null,
                        Reply_id = null,
                        message = null,
                        Created_at = userInfo.Created_at,
                        Updated_at = userInfo.Created_at
                    };
                    cares.Add(a);
                }
                var result = new userCareValue
                {
                    Status = "0",
                    Cares = cares
                };
                return result;
            }
            catch
            {
                var result = new userCareValue
                {
                    Status = "1",
                };
                return result;
            }
        }

        // GET: api/user/diary  
        /// <summary>
        /// 14.日記列表資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("diary")]
        public async Task<UserDiaryValue> GetUserDiary()
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var user_weight = _context.Weight.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).ToArray();
                var user_BP = _context.BloodPressure.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).ToArray();
                var user_BS = _context.BloodSugar.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).ToArray();
                List<DiaryValue> diary_result = new List<DiaryValue>();
                foreach (var userInfo in user_weight)
                {
                    DiaryValue weight = new DiaryValue()
                    {
                        Id = userInfo.ID,
                        User_id = userInfo.ID,
                        Weight = userInfo.Weight,
                        Body_fat = userInfo.Body_fat,
                        Bmi = userInfo.Bmi,
                        Recorded_at = userInfo.Recorded_at,
                        Type = "weight"
                    };
                    diary_result.Add(weight);
                }

                foreach (var userInfo in user_BP)
                {
                    DiaryValue BP = new DiaryValue()
                    {
                        Id = userInfo.ID,
                        User_id = userInfo.ID,
                        Systolic = userInfo.Systolic,
                        Diastolic = userInfo.Diastolic,
                        Pulse = userInfo.Pulse,
                        Recorded_at = userInfo.Recorded_at,
                        Type = "blood_pressure"
                    };
                    diary_result.Add(BP);
                }

                foreach (var userInfo in user_BS)
                {
                    DiaryValue BS = new DiaryValue()
                    {
                        Id = userInfo.ID,
                        User_id = userInfo.ID,
                        Sugar = userInfo.Sugar,
                        timeperiod = userInfo.timeperiod,
                        Recorded_at = userInfo.Recorded_at,
                        Type = "blood_pressure"
                    };
                    diary_result.Add(BS);
                }
                var result = new UserDiaryValue
                {
                    Status = "0",
                    Diary = diary_result
                };
                return result;
            }
            catch
            {
                var result = new UserDiaryValue
                {
                    Status = "1",
                };
                return result;
            }

        }

    }
}


