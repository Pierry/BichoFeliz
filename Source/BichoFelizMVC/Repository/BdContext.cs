using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BichoFelizMVC.Controllers.Repository.Base;
using BichoFelizMVC.Models;

namespace BichoFelizMVC.Repository {
  public class BdContext {
    private static readonly BdContext instance = new BdContext();
    private readonly BichoFelizMVCEntities _db = new BichoFelizMVCEntities();

    static BdContext() {}

    private BdContext() {}

    public static BdContext Instance {
      get { return instance; }
    }

    public BichoFelizMVCEntities GetDBConnection() {
      return _db;
    }
  }
}