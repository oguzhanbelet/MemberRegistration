﻿using DevFramework.Core.DataAccess;
using MemberRegistration.Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.DataAccess.Abstract
{
    public interface IMemberDal:IEntityRepository<Member>
    {
    }
}
