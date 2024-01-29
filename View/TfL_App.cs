using System.Diagnostics;
using System.Xml.Linq;
using TfL_Walking_Distance_Version2.Model;
using static System.Collections.Specialized.BitVector32;

namespace TfL_Walking_Distance_Version2.View
{
     class TfL_App
    {
   
        protected MyList routeRecords = new MyList();   
        protected MyList stationRecords = new MyList();   
        protected Stopwatch timer = new Stopwatch();
        

        public TfL_App() { }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("**************************************");
            Console.WriteLine("******** TfL Walking Distance ********");
            Console.WriteLine("**************************************");
            Console.WriteLine("");

            Console.WriteLine("*     Welcome to TfL Application     *");
            Console.WriteLine("*     Check your walking distance    *");
            Console.WriteLine("");
            


            int j = 0;
            while (j < 1)
            {
                Console.WriteLine("Please press the option below:");
                Console.WriteLine("0. Customer");
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Exit");
                Console.WriteLine("Enter option : ");
                string val = Console.ReadLine();
                if (val != null)
                {
                    try
                    {
                        int val1 = int.Parse(val);
                        if (val1 == 0 || val1 == 1 || val1 == 2)
                        {
                            Console.Clear();
                            if (val1 == 1)
                            {
                                User appUser = new Manager();
                                Console.WriteLine("########################################");
                                Console.WriteLine("###     This is the Manager's Tab    ###");
                                Console.WriteLine("########################################");


                                int a = 0;
                                while (a < 1)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Please the option below");
                                    Console.WriteLine("1. Add Or Remove walking time delay to a Route");
                                    Console.WriteLine("2. Update Route Status");
                                    Console.WriteLine("3. Print list of Impossible Route");
                                    Console.WriteLine("4. Print list of Delayed Route");
                                    Console.WriteLine("5. Back");
                                    Console.WriteLine("Enter option : ");
                                    string val5 = Console.ReadLine();
                                    try
                                    {
                                        int val6 = int.Parse(val5);
                                        Console.Clear();
                                        if (appUser.UserType == "Manager")
                                        {
                                            switch (val6)
                                            {
                                                case 1:
                                                    Console.WriteLine("Add Or Remove walking time (delay) to a Route");
                                                    Console.WriteLine("Please enter source station");
                                                    string stNameAddSt = Console.ReadLine();
                                                    int x = 0;
                                                    while (x < 1)
                                                    {
                                                        if (CheckStation(stNameAddSt))
                                                        {
                                                            x++;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Start Station is not in London Zone 1");
                                                            Console.WriteLine("Please enter station again : ");
                                                            stNameAddSt = Console.ReadLine();
                                                        }
                                                    }
                                                    Console.WriteLine("Please enter destination station");
                                                    string stNameAddDt = Console.ReadLine();
                                                    int y = 0;
                                                    while (y < 1)
                                                    {
                                                        if (CheckStation(stNameAddDt))
                                                        {
                                                            y++;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Destination Station is not in London Zone 1");
                                                            Console.WriteLine("Please enter station again : ");
                                                            stNameAddDt = Console.ReadLine();
                                                        }
                                                    }
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Please input delay time");
                                                    Console.WriteLine("To remove delay time -> Set time to 0");
                                                    Console.WriteLine("To add delay time -> Set time to value");
                                                    Console.WriteLine("Enter time : ");
                                                    int z = 0;
                                                    string stNameAddTt = Console.ReadLine();
                                                    int stNameAddInt = 0;
                                                    while (z < 1)
                                                    {
                                                        try
                                                        {
                                                            stNameAddInt = int.Parse(stNameAddTt);
                                                            z++;
                                                        }
                                                        catch (SystemException ex)
                                                        {
                                                            Console.WriteLine("Execepetion Message: " + ex.Message);
                                                            Console.WriteLine("please input a valid value");
                                                            stNameAddTt = Console.ReadLine();
                                                        }
                                                    }
                                                    Console.WriteLine("Reason for adding or removing");
                                                    string stNameReason = Console.ReadLine();
                                                    Console.WriteLine("");
                                                    timer.Start();
                                                    bool add = SetDelayTime(stNameAddSt, stNameAddDt, stNameAddInt, stNameReason);
                                                    if (add)
                                                    {
                                                        Console.WriteLine($"Delay {stNameAddInt} has been added to route {stNameAddSt} -> {stNameAddDt}");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Error adding delay");
                                                    }
                                                    timer.Stop();
                                                    TimeSpan time5 = timer.Elapsed;
                                                    Console.WriteLine("");
                                                    Console.WriteLine($"Time taken to add delay {stNameAddInt} to route {stNameAddSt} -> {stNameAddDt}  = {time5.Milliseconds} Milliseconds");
                                                    Console.ReadLine();
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Update Route Status");
                                                    Console.WriteLine("Please enter source station");
                                                    string stNameRsSt = Console.ReadLine();
                                                    int c = 0;
                                                    while (c < 1)
                                                    {
                                                        if (CheckStation(stNameRsSt))
                                                        {
                                                            c++;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Start Station is not in London Zone 1");
                                                            Console.WriteLine("Please enter station again : ");
                                                            stNameRsSt = Console.ReadLine();
                                                        }
                                                    }
                                                    Console.WriteLine("Please enter destination station");
                                                    string stNameRsDt = Console.ReadLine();
                                                    int d = 0;
                                                    while (d < 1)
                                                    {
                                                        if (CheckStation(stNameRsDt))
                                                        {
                                                            d++;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Destination Station is not in London Zone 1");
                                                            Console.WriteLine("Please enter station again : ");
                                                            stNameRsDt = Console.ReadLine();
                                                        }
                                                    }
                                                    Console.WriteLine("Please the option below to update station status");
                                                    Console.WriteLine("1. Open");
                                                    Console.WriteLine("2. Closed");
                                                    Console.WriteLine("Enter Option");
                                                    string stNameRsSs = Console.ReadLine();
                                                    int stNameRsSsInt = 0;
                                                    STATUS update = STATUS.Open;
                                                    int e = 0;
                                                    while (e < 1)
                                                    {
                                                        try
                                                        {
                                                            stNameRsSsInt = int.Parse(stNameRsSs);
                                                            if (stNameRsSsInt == 1)
                                                            {
                                                                update = STATUS.Open;
                                                                e++;
                                                            }
                                                            else if (stNameRsSsInt == 2)
                                                            {
                                                                update = STATUS.Closed;
                                                                e++;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Input number not valid");
                                                            }

                                                        }
                                                        catch (SystemException ex)
                                                        {
                                                            Console.WriteLine("Execepetion Message: " + ex.Message);
                                                            Console.WriteLine("please input a valid value");
                                                            stNameRsSs = Console.ReadLine();
                                                        }
                                                        Console.WriteLine("");
                                                        timer.Start();
                                                        bool rsUpdate = SetRouteUpdate(stNameRsSt, stNameRsDt, update);
                                                        
                                                        if (rsUpdate)
                                                        {
                                                            Console.WriteLine($"Status updated {update} has been added to route {stNameRsSt} -> {stNameRsDt}");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Error updating route");
                                                        }
                                                        timer.Stop();
                                                        TimeSpan time4 = timer.Elapsed;
                                                        Console.WriteLine("");
                                                        Console.WriteLine($"Time taken to process updating as {update} route {stNameRsSt} -> {stNameRsDt}   = {time4.Milliseconds} Milliseconds");
                                                    }
                                                    Console.ReadLine();
                                                    break;
                                                case 3:
                                                    Console.WriteLine("Print list of Impossible Route");
                                                    Console.WriteLine("");
                                                    timer.Stop();
                                                    PrintImposible();
                                                    timer.Stop();
                                                    TimeSpan time3 = timer.Elapsed;
                                                    Console.WriteLine("");
                                                    Console.WriteLine($"Time taken to Print list of Impossible Route  = {time3.Milliseconds} Milliseconds");
                                                    Console.ReadLine();
                                                    break;
                                                case 4:
                                                    Console.WriteLine("Print list of Delayed Route");
                                                    Console.WriteLine("");
                                                    timer.Stop();
                                                    PrintDelayed();
                                                    timer.Stop();
                                                    TimeSpan time2 = timer.Elapsed;
                                                    Console.WriteLine("");
                                                    Console.WriteLine($"Time taken to Print list of Delayed Route  = {time2.Milliseconds} Milliseconds");
                                                    Console.ReadLine();
                                                    break;
                                                case 5:
                                                    a++;
                                                    break;
                                                default:
                                                    Console.WriteLine("Please enter number within range");
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Contact your Admin. You do not have adequate right");
                                        }
                                    }
                                    catch (SystemException ex)
                                    {
                                        Console.WriteLine("Execepetion Message: " + ex.Message);
                                        Console.WriteLine("please input a valid value");
                                    }
                                }
                            }
                            else if (val1 == 0)
                            {
                                Console.WriteLine("########################################");
                                Console.WriteLine("###     This is the Customer's Tab   ###");
                                Console.WriteLine("########################################");
                                int b = 0;
                                while (b < 1)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Please the option below");
                                    Console.WriteLine("1. Find routes fastest path ");
                                    Console.WriteLine("2. Display tube information");
                                    Console.WriteLine("3. Back");
                                    Console.WriteLine("Enter option : ");
                                    string val2 = Console.ReadLine();
                                    try
                                    {
                                        int val3 = int.Parse(val2);
                                        Console.Clear();
                                        switch (val3)
                                        {
                                            case 1:
                                                Console.WriteLine("Find routes fastest path from Source Station to Destination Station");
                                                Console.WriteLine("Enter Source Station name: ");
                                                string stName = Console.ReadLine();
                                                int i = 0;
                                                while (i < 1)
                                                {
                                                    if (CheckStation(stName))
                                                    {
                                                        i++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Start Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        stName = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("Enter Destination Station name: ");
                                                string edName = Console.ReadLine();
                                                int h = 0;
                                                while (h < 1)
                                                {
                                                    if (CheckStation(edName))
                                                    {
                                                        h++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Destination Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        edName = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("");
                                                timer.Start();
                                                GetShortestPath(stName, edName);
                                                timer.Stop();
                                                TimeSpan time = timer.Elapsed;
                                                Console.WriteLine("");
                                                Console.WriteLine($"Time taken from to search for route {stName} -> {edName} = {time.Milliseconds} Milliseconds");
                                                Console.ReadLine();
                                                break;
                                            case 2:
                                                Console.WriteLine("Display tube information");
                                                Console.WriteLine("Please enter tube name:");
                                                int c = 0;
                                                while (c < 1)
                                                {
                                                    string varName = Console.ReadLine();
                                                    if (CheckTubeName(varName))
                                                    {
                                                        timer.Start();
                                                        Console.WriteLine("");
                                                        GetTubeDetails(varName);
                                                        timer.Stop();
                                                        TimeSpan time1 = timer.Elapsed;
                                                        Console.WriteLine("");
                                                        Console.WriteLine($"Time taken to display tube information with tubename {varName} = {time1.Milliseconds} Milliseconds");
                                                        c++;
                                                        Console.ReadLine();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Tube Name is not in our record for Zone 1");
                                                        Console.WriteLine("Please input tube name");
                                                    }
                                                }
                                                break;
                                            case 3:
                                                b++;
                                                break;
                                            default:
                                                Console.WriteLine("Please enter number within range");
                                                break;
                                        }
                                    }
                                    catch (SystemException ex)
                                    {
                                        Console.WriteLine("Execepetion Message: " + ex.Message);
                                        Console.WriteLine("please input a valid value");
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("Good Bye.....");
                                Console.WriteLine("Please any Key");
                                j++;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Execepetion Message: {val1} is not in the menu");
                            Console.WriteLine("please input a valid value");
                        }
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine("Execepetion Message: " + ex.Message);
                        Console.WriteLine("please input a valid value");
                    }
                }
                else
                {
                    Console.WriteLine("please input a value - Input Empty");
                }
            }

        }

        public string[] GetFiles()
        {
            string path = "TFLRoute";
            string[] files = Array.Empty<string>();

            try
            {
                files = Directory.GetFiles(path);

                foreach (string file in files)
                {
                    files.Append(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred getting file : " + ex.Message);
            }

            return files;
        }

        public void StoreRecords(string[] filepath)
        {
            foreach (string fp in filepath)
            {
                string[] lines = File.ReadAllLines(fp);

                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line) || line.Contains("\t")) continue;
                    string tubeLineName = Path.GetFileNameWithoutExtension(fp);
                    string[] lineArray = line.Trim().Split(',');
                    string sourceStation = lineArray[0];
                    string[] timeArray = lineArray[1].Trim().Split('=');
                    string destStation = timeArray[0];
                    int timeDiff = 0;
                    try
                    {
                        timeDiff = int.Parse(timeArray[1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Warning : Time from file is compliance " + ex.Message);
                    }

                    int create = 0;

                    if (stationRecords.GetHead() != null) 
                    {
                        MyNode current = new MyNode();

                        current = stationRecords.GetHead();

                        while (current != null)
                        {
                            TubeStation tubeStation = new TubeStation();
                            tubeStation = (TubeStation)current.getItem();
                            string see = tubeStation.Name.ToLower().Trim();
                            if (tubeStation.Name.ToLower().Trim() == sourceStation.ToLower().Trim())
                            {
                                create++;
                                break;
                            }
                            current = current.getNext();
                        }
                    }
                    if (create == 0)
                    {
                        TubeStation Station = new TubeStation(sourceStation);
                       
                        stationRecords.InsertAtTail(Station);
                    }

                    int create1 = 0;

                    if (stationRecords.GetHead() != null)
                    {
                        MyNode current = new MyNode();

                        current = stationRecords.GetHead();
                        while (current != null)
                        {
                            TubeStation tubeStation = new TubeStation();
                            tubeStation = (TubeStation)current.getItem();
                            string see = tubeStation.Name.ToLower().Trim();
                            if (tubeStation.Name.ToLower().Trim() == destStation.ToLower().Trim())
                            {
                                create1++;
                                break;
                            }
                            current = current.getNext();
                        }
                    }

                    if (create1 == 0)
                    {
                        TubeStation Station1 = new TubeStation(destStation);
                        stationRecords.InsertAtTail(Station1);
                    }

                    Tube route = new Tube(sourceStation, destStation, timeDiff, tubeLineName);
                    routeRecords.InsertAtTail(route);
                }
            }
           
        }

        public int[] DijkstraShortestPath(MyList station, MyList tube, string startVertex, string endVertex)
        {

            int stationCount = station.IsCount();
            int[] vertexPath = new int[stationCount];
            bool[] visitedVertex = new bool[stationCount];
            int[] pathLength = new int[stationCount];

            MyList stationDictionary = new MyList();
            int k = 0;

            if (station.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = station.GetHead();
                while (current != null)
                {
                    TubeStation tubeStation = new TubeStation();
                    tubeStation = (TubeStation)current.getItem();
                    string name = tubeStation.Name;
                    MyDictionary dict = new MyDictionary(k, name);
                    stationDictionary.InsertAtTail(dict);
                    current = current.getNext();
                    k++;
                }	

            }

            for (int i = 0; i < stationCount; i++)
            {
                pathLength[i] = int.MaxValue;
                vertexPath[i] = -1;
            }

            int startKey = 0;
            int endKey = 0;

            if (stationDictionary.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = stationDictionary.GetHead();
                while (current != null)
                {
                    MyDictionary Dict = new MyDictionary();
                    Dict = (MyDictionary)current.getItem();
                    string dname = Dict.DictValue;
                    int dkey = Dict.DictKey;
                    if (dname.Trim().ToLower() == startVertex.Trim().ToLower())
                    {
                        startKey = dkey;
                    }

                    if (dname.Trim().ToLower() == endVertex.Trim().ToLower())
                    {
                        endKey = dkey;
                    }
                    
                    current = current.getNext();
                }
            }


            pathLength[startKey] = 0;


            for (int i = 0; i < stationCount; i++)
            {
                int vertexCurrentSearch = -1;
                int defaultPL = int.MaxValue;

                for (int j = 0; j < stationCount; j++)
                {
                    if (!visitedVertex[j] && pathLength[j] < defaultPL)
                    {
                        defaultPL = pathLength[j];
                        vertexCurrentSearch = j;
                    }
                }


                if (vertexCurrentSearch == -1 || vertexCurrentSearch == endKey)
                {
                    break;
                }

                visitedVertex[vertexCurrentSearch] = true;

                string currentVertex = "";
                
                if (stationDictionary.GetHead() != null)
                {
                    MyNode current = new MyNode();
                    current = stationDictionary.GetHead();
                    while (current != null)
                    {
                        MyDictionary Dict = new MyDictionary();
                        Dict = (MyDictionary)current.getItem();
                        string dname = Dict.DictValue;
                        int dkey = Dict.DictKey;
                        if (dkey == vertexCurrentSearch)
                        {
                            currentVertex = dname;
                        }
                        current = current.getNext();
                    }
                }


                if (tube.GetHead() != null)
                {
                    MyNode current = new MyNode();
                    current = tube.GetHead();
                    while (current != null)
                    {
                        Tube tb = new Tube();
                        
                        tb = (Tube)current.getItem();
                        
                        if (tb.SourceRoute == currentVertex && tb.Status == STATUS.Open)
                        {
                            string ntVertex = tb.DestinationRoute.Trim();

                            int nearestVertex = 0;

                            if (stationDictionary.GetHead() != null)
                            {
                                MyNode current1 = new MyNode();
                                current1 = stationDictionary.GetHead();
                                while (current1 != null)
                                {
                                    MyDictionary Dict = new MyDictionary();
                                    Dict = (MyDictionary)current1.getItem();
                                    string dname = Dict.DictValue;
                                    int dkey = Dict.DictKey;
                                    if (dname.Trim().ToLower() == ntVertex.Trim().ToLower())
                                    {
                                        nearestVertex = dkey;
                                    }
                                    current1 = current1.getNext();
                                }
                            }


                            int vertexTime = tb.RouteTime();

                            if (!visitedVertex[nearestVertex])
                            {
                                int weight = pathLength[vertexCurrentSearch] + vertexTime;

                                if (weight < pathLength[nearestVertex])
                                {
                                    pathLength[nearestVertex] = weight;
                                    vertexPath[nearestVertex] = vertexCurrentSearch;
                                }
                            }
                        }
                        current = current.getNext();
                    }
                }
            }
            return vertexPath;
        }

        public void GetShortestPath(string start, string end)
        {
            int[] shortestqueuedVertex = DijkstraShortestPath(stationRecords, routeRecords, start, end);

            MyList stationDictionary = new MyList();
            int k = 0;
            
            if (stationRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = stationRecords.GetHead();
                while (current != null)
                {
                    TubeStation tubeStation = new TubeStation();
                    tubeStation = (TubeStation)current.getItem();
                    string name = tubeStation.Name;
                    MyDictionary dict = new MyDictionary(k, name);
                    stationDictionary.InsertAtHead(dict);
                    current = current.getNext();
                    k++;
                }
            }


            int endKey = 0;
            int startKey = 0;

            if (stationDictionary.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = stationDictionary.GetHead();
                while (current != null)
                {
                    MyDictionary Dict = new MyDictionary();
                    Dict = (MyDictionary)current.getItem();
                    string dname = Dict.DictValue;
                    int dkey = Dict.DictKey;
                    if (dname.Trim().ToLower() == start.Trim().ToLower())
                    {
                        startKey = dkey;
                    }

                    if (dname.Trim().ToLower() == end.Trim().ToLower())
                    {
                        endKey = dkey;
                    }

                    current = current.getNext();
                }
            }


            Console.WriteLine("##########################################");
            Console.WriteLine("#     Shortest Route Display             #");
            Console.WriteLine("##########################################");
            Console.WriteLine("");
            Console.WriteLine($"Route:   {start}  to  {end} :");

            int totalTime = 0;
            int vertexId = endKey;
            

            MyList queuedVertex = new MyList();

            while (vertexId != startKey)
            {
                queuedVertex.InsertAtHead(vertexId);
                vertexId = shortestqueuedVertex[vertexId];
            }
            queuedVertex.InsertAtHead(startKey);

            int counter = 2;
            bool writeStart = true;
            bool isChange = false;
            string tubeline = "";
            string previousTubeName = "";
            while (queuedVertex.IsCount() > 1)
            {
                MyNode cur1 = new MyNode();
                cur1 = queuedVertex.GetHead();
                int vertexInt1 = Convert.ToInt32(cur1.getItem());

                queuedVertex.DeleteHead();

                MyNode cur2 = new MyNode();
                cur2 = queuedVertex.GetHead();
                int vertexInt2 = Convert.ToInt32(cur2.getItem());

                string vertexName1 =  "";
                string vertexName2 =  "";

                if (stationDictionary.GetHead() != null)
                {
                    MyNode current = new MyNode();
                    current = stationDictionary.GetHead();
                    while (current != null)
                    {
                        MyDictionary Dict = new MyDictionary();
                        Dict = (MyDictionary)current.getItem();
                        string dname = Dict.DictValue;
                        int dkey = Dict.DictKey;
                        if (dkey== vertexInt1)
                        {
                            vertexName1 = dname;
                        }

                        if (dkey == vertexInt2)
                        {
                            vertexName2 = dname;
                        }
                        current = current.getNext();
                    }
                }

                int routeTime = 0;

                if (routeRecords.GetHead() != null)
                {
                    MyNode current = new MyNode();
                    current = routeRecords.GetHead();
                    while (current != null)
                    {
                        Tube tb = new Tube();
                        tb = (Tube)current.getItem();
                        if (tb.SourceRoute.Trim().ToLower() == vertexName1.Trim().ToLower() && tb.DestinationRoute.Trim().ToLower() == vertexName2.Trim().ToLower())
                        {
                            routeTime = tb.RouteTime();
                            tubeline = tb.TubeName;
                            if (string.IsNullOrEmpty(previousTubeName))
                            {
                                previousTubeName = tubeline;
                            }
                            if (previousTubeName.Trim().ToLower() != tubeline.Trim().ToLower())
                            {
                                isChange = true;
                                previousTubeName = tubeline;
                            }
                            break;
                        }
                        current = current.getNext();
                    }
                }
                totalTime += routeTime;

                if (writeStart)
                {
                    Console.WriteLine($"({1}) Start:   {start} ({tubeline})");
                    writeStart = false;
                }

                if (isChange)
                {
                    Console.WriteLine($"({counter}) Change:  {vertexName1} ({tubeline}) to {vertexName2} ({tubeline}) -> {routeTime} min");
                    counter++;
                    isChange = false;
                }
                else
                {
                    Console.WriteLine($"({counter})          {vertexName1} ({tubeline}) to {vertexName2} ({tubeline}) -> {routeTime} min");
                    counter++;
                }
            }

            Console.WriteLine($"({counter}) End:     {end} ({tubeline})");
            Console.WriteLine($"Total Journey Time: {totalTime} minutes");

        }

        public bool CheckStation(string name)
        {
            if (stationRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = stationRecords.GetHead();
                while (current != null)
                {
                    TubeStation tb = new TubeStation();
                    tb = (TubeStation)current.getItem();
                    if (tb.Name.Trim().ToLower() == name.Trim().ToLower()) return true;
                    current = current.getNext();
                }
            }
            return false;
        }

        public bool CheckTubeName(string name)
        {
            if (routeRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = routeRecords.GetHead();
                while (current != null)
                {
                    Tube tb = new Tube();
                    tb = (Tube)current.getItem();
                    if (tb.TubeName.Trim().ToLower() == name.Trim().ToLower()) return true;
                    current = current.getNext();
                }
            }
            return false;
        }

        public void GetTubeDetails(string name)
        {
            Console.WriteLine("####################################");
            Console.WriteLine("#######  Tube Information     ######");
            Console.WriteLine("####################################");
            Console.WriteLine("");
            Console.WriteLine($"Tube information for {name}");

            if (routeRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = routeRecords.GetHead();
                while (current != null)
                {
                    Tube tb = new Tube();
                    tb = (Tube)current.getItem();

                    if (tb.TubeName.Trim().ToLower() == name.Trim().ToLower())
                    {
                        string source = tb.SourceRoute;
                        string destination = tb.DestinationRoute;
                        int time = tb.RouteTime();
                        Console.WriteLine($"Source: {source}  Destination: {destination}  Time: {time}");
                    }
                    
                    current = current.getNext();
                }
            }

        }

        public bool SetDelayTime(string sName, string dName, int t, string rs)
        {
            if (routeRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = routeRecords.GetHead();
                while (current != null)
                {
                    Tube tb = new Tube();
                    tb = (Tube)current.getItem();
                    
                    if (tb.SourceRoute.Trim().ToLower() == sName.Trim().ToLower() && tb.DestinationRoute.Trim().ToLower() == dName.Trim().ToLower())
                    {
                        tb.Delay = t;
                        tb.DelayReason = rs;
                        return true;
                    }
                    
                    current = current.getNext();
                }
            }
            return false;
        }

        public bool SetRouteUpdate(string sName, string dName, STATUS st)
        {
            if (routeRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = routeRecords.GetHead();
                while (current != null)
                {
                    Tube tb = new Tube();
                    tb = (Tube)current.getItem();

                    if (tb.SourceRoute.Trim().ToLower() == sName.Trim().ToLower() && tb.DestinationRoute.Trim().ToLower() == dName.Trim().ToLower())
                    {
                        tb.Status = st;
                        return true;
                    }

                    current = current.getNext();
                }
            }
            return false;
        }

        public void PrintImposible()
        {
            int counter = 1;

            if (routeRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = routeRecords.GetHead();
                while (current != null)
                {
                    Tube tb = new Tube();
                    tb = (Tube)current.getItem();

                    if (tb.Status == STATUS.Closed)
                    {
                        Console.WriteLine($"({counter})  source {tb.SourceRoute}  destination {tb.DestinationRoute}  Tube {tb.TubeName}");
                        counter++;
                    }

                    current = current.getNext();
                }
            }
            if (counter > 1)
            {
                Console.WriteLine("Above are the listed of closed route");
            }
            else
            {
                Console.WriteLine("There are no closed route on the map");
            }
        }

        public void PrintDelayed()
        {
            int counter = 1;

            if (routeRecords.GetHead() != null)
            {
                MyNode current = new MyNode();
                current = routeRecords.GetHead();
                while (current != null)
                {
                    Tube tb = new Tube();
                    tb = (Tube)current.getItem();

                    if (tb.Delay > 0)
                    {
                        Console.WriteLine($"({counter})  source {tb.SourceRoute} -> destination {tb.DestinationRoute} -> Tube {tb.TubeName} Delay -> {tb.Delay} -> Reason {tb.DelayReason}");
                        counter++;
                    }

                    current = current.getNext();
                }
            }

            if (counter > 1)
            {
                Console.WriteLine("Above are the listed of closed route");
            }
            else
            {
                Console.WriteLine("There are no closed route on the map");
            }
        }
    }
}
