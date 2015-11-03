﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS.DocumentRepository;
using WKUK.CCH.Document.DocMgmt.DocManager;
using MYOB.DAL;

namespace CS.DocumentRepositoryTests
{
    [TestClass]
    [DeploymentItem("lookup.xml")]
    public class CCHDocumentRepositoryTests
    {
        [TestMethod]
        public void CCHDocumentRepository_Create()
        {
            var contactID = 1323;
            var centralDAL = new DAL("0");
            var docManager = new DocManager(centralDAL);
            var sut = new CCHDocumentRepository(docManager, contactID);
        }

        [TestMethod]
        public void CCHDocumentRepository_GetDocuments()
        {
            var contactID = 1323;
            var centralDAL = new DAL("0");
            var docManager = new DocManager(centralDAL);
            var sut = new CCHDocumentRepository(docManager, contactID);
            var docs = sut.GetDocuments();
            Assert.AreNotEqual(0, docs.Count());
        }
    }
}
