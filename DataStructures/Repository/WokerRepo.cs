using System;
using WorkerData.Repostiories.Interfaces;


namespace WorkerData.Repostiories
{
    public class WorkerRepo : IWorkerRepo
    {

        public WorkerRepo()
        {
        
        }


        public String[] getList()
        {
            var movies = new String[]{"WorkerRights", "DinMor er fed og Grim"};
            return movies;
        }
    }
    

    
}