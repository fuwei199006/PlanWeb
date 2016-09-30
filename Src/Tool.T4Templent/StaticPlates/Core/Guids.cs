﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.
namespace Tool.T4Templent.StaticPlates.Core
{
    using System;

    internal static class GuidList
    {
        public const string guidDbContextPackagePkgString = "2b119c79-9836-46e2-b5ed-eb766cebbf7c";
        public const string guidDbContextPackageCmdSetString = "c769a05d-8d51-4919-bfe6-5f35a0eaf27e";

        public static readonly Guid guidDbContextPackageCmdSet = new Guid(guidDbContextPackageCmdSetString);
    }
}