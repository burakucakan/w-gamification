using System.Collections.Specialized;
using System.ServiceModel.Activation;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using w2.Ws.Models;
using w2.Service.Gigya;
using w2.DB;
using w2.Service;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using w2.Service.Gigya.GM;
using w2.Service.Gigya.Comments;
using System.Web.Services.Protocols;

namespace w2.Ws.WS.Core
{
    public class Comments
    {
        public DeleteCommentResponse DeleteComment(string Key, DeleteComment ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<DeleteCommentResponse>();
        }

        public FlagCommentResponse FlagComment(string Key, FlagComment ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<FlagCommentResponse>();
        }

        public GetCategoryInfoResponse GetCategoryInfo(string Key, GetCategoryInfo ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetCategoryInfoResponse>();
        }

        public GetCommentCountsResponse GetCommentCounts(string Key, GetCommentCounts ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetCommentCountsResponse>();
        }

        public GetStreamInfoResponse GetStreamInfo(string Key, GetStreamInfo ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetStreamInfoResponse>();
        }

        public CommentResponse Comment(string Key, Comment ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<CommentResponse>();
        }



        public GetThreadResponse GetThread(string Key, GetThread ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetThreadResponse>();
        }

        public Service.Gigya.Comments.GetTopRatedStreamsResponse GetTopRatedStreams(string Key, GetTopRatedStreams ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<Service.Gigya.Comments.GetTopRatedStreamsResponse>();
        }

        public GetTopStreamsResponse GetTopStreams(string Key, GetTopStreams ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetTopStreamsResponse>();
        }

        public GetUserCommentsResponse GetUserComments(string Key, GetUserComments ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<GetUserCommentsResponse>();
        }

        public PostCommentResponse PostComment(string Key, PostComment ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<PostCommentResponse>();
        }

        public SenderResponse Sender(string Key, Sender ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SenderResponse>();
        }

        public SetCategoryInfoResponse SetCategoryInfo(string Key, SetCategoryInfo ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetCategoryInfoResponse>();
        }

        public SetStreamInfoResponse SetStreamInfo(string Key, SetStreamInfo ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetStreamInfoResponse>();
        }

        public SetUserOptionsResponse SetUserOptions(string Key, SetUserOptions ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SetUserOptionsResponse>();
        }

        public SubscribeResponse Subscribe(string Key, Subscribe ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<SubscribeResponse>();
        }

        public UnsubscribeResponse Unsubscribe(string Key, Unsubscribe ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<UnsubscribeResponse>();
        }

        public UpdateCommentResponse UpdateComment(string Key, UpdateComment ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<UpdateCommentResponse>();
        }

        public VoteResponse Vote(string Key, Vote ent)
        {

            var request = new GigyaRequest(ent);
            return request.Send<VoteResponse>();
        }
    }
}