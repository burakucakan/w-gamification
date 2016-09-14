using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using w2.Service.Gigya.GM.CustomObjects;

namespace w2.Service.Gigya.GM
{
    public class GetTopUsersResponse : BaseResponse
    {

        private IList<UserObj> _listUserObj;

        [JsonProperty("users")]
        public User[] Users { 
            set {
                _listUserObj = new List<UserObj>();
                UserObj userObj;
                foreach (var item in value)
                {
                    userObj = new UserObj();
                    userObj.UID = item.UID;
                    userObj.Rank = item.Rank;
                    userObj.Type = item.Type;
                    _listUserObj.Add(userObj);
                }
            }
        }

        [DataMember]
        public IEnumerable<UserObj> UserObjList { 
            get { return _listUserObj; } 
        }
    }
}