using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.Service.Gigya
{
    public class ResponseCodes
    {
        public enum ErrorCode
        {
            NoError = 0,

            MsisdnStartZero = 1001,
            NoAuthorization = 1002,
            MissingParameter = 1003
        }

        public enum GigyaErrorCode
        {
            NoError = 0,
            DataPending = 100001,
            OperationCanceled = 200001,
            PermissionNotGranted = 200003,
            OKWithErrors = 200008,
            AccountPendingRegistration = 206001,
            AccountPendingVerification = 206002,
            AccountMissingLoginID = 206003,
            InvalidDataCenter = 301001,
            InvalidRequestFormat = 400001,
            MissingRequiredParameter = 400002,
            UniqueIdentifierExists = 400003,
            InvalidParameterFormat = 400004,
            InvalidParameterValue = 400006,
            DuplicateValue = 400007,
            InvalidAuthenticationHeader = 400008,
            ValidationError = 400009,
            InvalidRedirectURI = 400011,
            InvalidResponseType = 400012,
            UnsupportedGrantType = 400013,
            InvalidGrant = 400014,
            CodeExpired = 400015,
            SchemaValidationFailed = 400020,
            CAPTCHAVerificationFailed = 400021,
            UniqueIndexValidation = 400022,
            InvalidTypeValidation = 400023,
            DynamicFieldsValidation = 400024,
            WriteAccessValidation = 400025,
            InvalidFormatValidation = 400026,
            RequiredValueValidation = 400027,
            SecurityVerificationFailed = 400050,
            MissingRequiredProviderParameter = 400060,
            MissingRequiredRecipientsParameter = 400070,
            MissingRequiredBodyParameter = 400080,
            MissingRequiredSubjectParameter = 400090,
            MissingRequiredApiKeyParameter = 400092,
            InvalidApiKeyParameter = 400093,
            MissingRequiredUidParameter = 400094,
            InvalidUidParameter = 400095,
            NotSupported = 400096,
            MissingRequiredTimestampParameter = 400097,
            InvalidTimestampParameter = 400098,
            InvalidProvider = 400099,
            NoProviders = 400100,
            PopupBlocked = 400101,
            InvalidEventHandler = 400102,
            InvalidContainerID = 400103,
            NotConnected = 400106,
            InvalidSiteDomain = 400120,
            ProviderConfigurationError = 400122,
            LimitReached = 400124,
            UnableToPostCommentYouhaveExceededtheRateLimit = 400125,
            InsufficientPointstoRedeem = 400127,
            InvalidPolicyConfiguration = 401000,
            InvalidSessionToken = 403001,
            RequestsTimestampAndTheServerTimeisLargerThan120Seconds = 403002,
            InvalidRequestSignature = 403003,
            DuplicateNonce = 403004,
            UnauthorizedUser = 403005,
            SecretSentOverHttp = 403006,
            PermissionDenied = 403007,
            InvalidOpenIDUrl = 403008,
            ProviderSessionExpired = 403009,
            InvalidSecret = 403010,
            Sessionhasexpired = 403011,
            NoValidSession = 403012,
            MissingRequestReferrer = 403015,
            UnexpectedProviderUser = 403017,
            PermissionNotRequested = 403022,
            NoUserPermission = 403023,
            ProviderLimitReached = 403024,
            InvalidToken = 403025,
            UnauthorizedAccessError = 403026,
            SessionExpiredRetry = 403030,
            ApprovedbyModerator = 403031,
            NoUserCookie = 403035,
            UnauthorizedPartner = 403036,
            PostDenied = 403037,
            NoLoginTicket = 403040,
            AccountDisabled = 403041,
            InvalidLoginID = 403042,
            LoginIdentifierExists = 403043,
            UnderageUser = 403044,
            InvalidSiteConfigurationError = 403045,
            DefaultApplicationConfigurationError = 403046,
            ThereisNoUserWithThatUsernameorEmail = 403047,
            NotFound = 404000,
            FriendNotFound = 404001,
            CategoryNotFound = 404002,
            UIDNotFound = 404003,
            InvalidAPIMethod = 405001,
            IdentityExists = 409001,
            RequestEntityTooLarge = 413001,
            CommentTextTooLarge = 413002,
            GeneralServerError = 500001,
            ServerLoginError = 500002,
            SessionMigrationError = 500014,
            InvalidSiteID = 500020,
            ProviderError = 500023,
            // Bu responseDan mevcut sonuna 2 ekledim  NoValidSession2 = 500024,
            NoValidSession2 = 500024,
            NetworkError = 500026,
            DatabaseError = 500028,
            //Bu responseDan mevcut sonuna 2 ekledim InvalidSiteDomain = 500030,
            InvalidSiteDomain2b = 500030,
            NoProviderApplication = 500031,
            LoadFailed = 500032,
            //InvalidAPIMethod = 501001,
            InvalidAPIMethod2 = 501001,
            Timeout = 504001,
            RequestTimeout = 504002,
        }

        public enum StatusCode
        {
            OK = 200,
        }

        public enum CallId
        {
            OK = 200,
        }


    }
}