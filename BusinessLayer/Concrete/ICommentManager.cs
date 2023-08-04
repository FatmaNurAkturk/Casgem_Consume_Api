﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ICommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public ICommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetByID(string id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public void TInsert(Comment t)
        {
            t.Id = ObjectId.GenerateNewId().ToString();
            _commentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
