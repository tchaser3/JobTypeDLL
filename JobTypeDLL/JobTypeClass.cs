/* Title:           Job Type Class
 * Date:            1-16-19
 * Author:          Terry Holmes
 * 
 * Description:     This is used for the job type */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace JobTypeDLL
{
    public class JobTypeClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        JobTypeDataSet aJobTypeDataSet;
        JobTypeDataSetTableAdapters.jobtypeTableAdapter aJobTypeTableAdapter;

        InsertJobTypeEntryTableAdapters.QueriesTableAdapter aInsertJobTypeTableAdapter;

        FindSortedJobTypeDataSet aFindSortedJobTypeDataSet;
        FindSortedJobTypeDataSetTableAdapters.FindSortedJobTypeTableAdapter aFindSortedJobTypeTableAdapter;

        public FindSortedJobTypeDataSet FindSortedJobType()
        {
            try
            {
                aFindSortedJobTypeDataSet = new FindSortedJobTypeDataSet();
                aFindSortedJobTypeTableAdapter = new FindSortedJobTypeDataSetTableAdapters.FindSortedJobTypeTableAdapter();
                aFindSortedJobTypeTableAdapter.Fill(aFindSortedJobTypeDataSet.FindSortedJobType);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Job Type Class // Find Sorted Job Type " + Ex.Message);
            }

            return aFindSortedJobTypeDataSet;
        }
        public bool InsertJobType(string strJobType)
        {
            bool blnFatalError = false;

            try
            {
                aInsertJobTypeTableAdapter = new InsertJobTypeEntryTableAdapters.QueriesTableAdapter();
                aInsertJobTypeTableAdapter.InsertJobType(strJobType);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Job Type Class // Insert Job Type " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public JobTypeDataSet GetJobTypeInfo()
        {
            try
            {
                aJobTypeDataSet = new JobTypeDataSet();
                aJobTypeTableAdapter = new JobTypeDataSetTableAdapters.jobtypeTableAdapter();
                aJobTypeTableAdapter.Fill(aJobTypeDataSet.jobtype);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Job Type Class // Get Job Type Info " + Ex.Message);
            }

            return aJobTypeDataSet;
        }
        public void UpdateJobTypeDB(JobTypeDataSet aJobTypeDataSet)
        {
            try
            {
                aJobTypeTableAdapter = new JobTypeDataSetTableAdapters.jobtypeTableAdapter();
                aJobTypeTableAdapter.Update(aJobTypeDataSet.jobtype);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Job Type Class // Update Job Type DB " + Ex.Message);
            }
        }
    }
}
