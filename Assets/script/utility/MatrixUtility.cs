 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatrixUtility {

    public string Name{ get; set; }
    int _maxRow;
    int _maxCol;
    int[,] _items;
    public MatrixUtility (int newMaxRow,int newMaxCol, string label) {

        _maxRow = newMaxRow;
        _maxCol = newMaxCol;
        Name = label;
        PopulateMatrix ();
        // SimulatePopulateMatrix();

    }

    private void PrintTitle () {

    //    Debug.Log ("->** " + name + " <-");

    }

    

    public void ShowResult () {

     //   PrintTitle ();

        for (int row = 0 ; row < _maxRow ; row++) {

            for (int column = 0 ; column < _maxCol ; column++) {

              //Debug.Log ("Row->  #" + row + " | Col->  #" + column + " Item: " + item[row,column]);

            }

        }


    }

    void SimulatePopulateMatrix () {

     //   PrintTitle ();
        _items = new int[_maxRow,_maxCol];
        int i = 0;

        for (int row = 0 ; row < _maxRow ; row++) {

            for (int column = 0 ; column < _maxCol ; column++) {

               // item[row,column] = listId[Random.Range (0,listId.Count)];

              // item[row,column] = listId[i];
               // i++;

              //Debug.Log ("Row->  #" + row + " | Col->  #" + column + " Item: " + item[row,column]);
            }

        }
        List<Vector2> list = new List<Vector2> ();    

        //ShowList (list);
    }

    public void PopulateMatrix () {

        _items = new int[_maxRow,_maxCol];
        PrintTitle ();

        for (int row = 0 ; row < _maxRow ; row++) {

            for (int column = 0 ; column < _maxCol ; column++) {

                _items[row,column] = -1;
              //  Debug.Log ("Row->  #" + row + " | Col->  #" + column + " Item: " + item[row,column]);
                
            }

        }

    }

    private void ShowList (List<Vector2> listResult) {

        PrintTitle ();

        foreach (var item in listResult) {
       //     Debug.Log ("Item: " + item);

        }

    }

    public int[,] ShowFullList () {

        return _items;
    }

    public void SetItem(List<Vector2> list, int id) {

        PrintTitle ();

        if (id >= 0) {            

            foreach (var location in list) {

                int row = (int) location.x;
                int column = (int) location.y;
                _items[row,column] = id;

              //  Debug.LogWarning ("Row->  #" + row + " | Col->  #" + column + " Item: " + id);


            }
         

        }
        else { Debug.LogWarning ("Do not use id number above 0 Zero"); }
        
    }

   

    public void ClearItemOnMatrix (int id) {

        PrintTitle ();

        if (id >= 0) {

            for (int row = 0 ; row < _maxRow ; row++) {

                for (int column = 0 ; column < _maxCol ; column++) {

                    
                    if (_items[row,column] == id) {

                        //Debug.LogWarning ("Before");
                        //Debug.Log ("Row->  #" + row + " | Col->  #" + column + " Item: " + item[row,column]);

                        _items[row,column] = -1;

                        //Debug.LogWarning ("After");
                        //Debug.Log ("Row->  #" + row + " | Col->  #" + column + " Item: " + item[row,column]);

                    }
                }

            }

        }

    }


    public List<Vector2> FindLocationById(int id) {

        List<Vector2> listResult = new List<Vector2> ();

        if(id >= 0) {

            for (int row = 0 ; row < _maxRow ; row++) {

                for (int column = 0 ; column < _maxCol ; column++) {

                    //int currentId = item[row,column];

                    if (_items[row,column] == id) {

                      //Debug.Log ("Row->  #" + row + " | Col->  #" + column + " Item: " + item[row,column]);
                        listResult.Add (new Vector2 (row, column));
                    }
                }
            }
        }

        return listResult;
    }


    public List<Vector2> LookForFreeArea(int number) {

        List<Vector2> listResult = new List<Vector2>();

        if(number == 1) {

            //Debug.LogWarning ("Selected: " + number);

            listResult = LookForAreaHorizontalPriority (number,1);

          //  ShowList (listResult);
            return listResult;
            
        }
      
        if (number == 2) {

            listResult = LookForAreaHorizontalPriority (number,1);

            if (listResult.Count > 1) {
               
                return listResult;

            }
            else {

                listResult = LookForAreaVerticalPriority (number,1);
                if (listResult.Count > 1) {

                    return listResult;

                }
            }
        }


        if (number == 3) {

            listResult = LookForAreaHorizontalPriority (number,1);

            if (listResult.Count > 2) {

                return listResult;

            }

            else {

                listResult = LookForAreaVerticalPriority (number,1);
                if (listResult.Count > 2) {

                    return listResult;

                }
            }

        }

        if (number == 5) {

            listResult = LookForAreaHorizontalPriority (number,1);

            if (listResult.Count > 4) {

                return listResult;

            }
            else {

                listResult = LookForAreaVerticalPriority (number,1);
                if (listResult.Count > 4) {

                    return listResult;

                }
            }

        }

        if (number == 4) {
           // Debug.LogWarning ("Searching 4 ");
            listResult = LookForAreaHorizontalPriority (2,2);

            if (listResult.Count > 3) {

               // ShowList (listResult);
                return listResult;

            }

            else {

                listResult = LookForAreaHorizontalPriority (4,1);
                if (listResult.Count > 3) {

                    // ShowList (listResult);
                    return listResult;

                }
                else {
                    listResult = LookForAreaVerticalPriority (4,1);
                    if (listResult.Count > 3) {

                        // ShowList (listResult);
                        return listResult;

                    }

                }           


            }
        }

        if (number == 6) {

            //Debug.LogWarning ("Searching  6");

            listResult = LookForAreaHorizontalPriority (3,2);

            if (listResult.Count > 5) {                                
               
               // ShowList (listResult);
                return listResult;

            }
            else {

                listResult = LookForAreaVerticalPriority (2,3);
                if (listResult.Count > 5) {                    
                  
                    ShowList (listResult);
                    return listResult;
                }


            }

        }

        if (number == 8) {

            //Debug.LogWarning ("Searching 8 ");
            listResult = LookForAreaHorizontalPriority (4,2);

            if (listResult.Count > 7) {

                //Debug.LogWarning (" LookForAreaHorizontalPriority (4,2)");              
                return listResult;

            }
            else {

                listResult = LookForAreaVerticalPriority (4,2);

                if (listResult.Count > 5) {
                
                  return listResult;
                }


            }
        }



            return listResult;
    }

    List<Vector2> LookForAreaHorizontalPriority (int numberHorizontal, int deep) {

        List<Vector2> listResult = new List<Vector2> ();        
        int colSelect = 0;
        
        //Looking for slot free on Horizontal
        for (int row = 0 ; row < _maxRow ; row++) {

            for (int column = 0 ; column < _maxCol ; column++) {

                //Debug.Log ("FOR column: " + column);

                if (_items[row,column] == -1) {

                    colSelect = column;
                    //Debug.Log ("------ First Free: -> Horizontal <-");
                    //Debug.Log ("Row: " + row + " Col: " + column + " | " + item[row,column]);

                    if (_maxCol - column >= numberHorizontal) {

                        //Debug.Log ("-> There is HOPE _H_");

                        for (int i = colSelect ; i < _maxCol ; i++) {

                            //Debug.Log ("Long Search");

                          
                            if (VerticalValidation (row,i,deep)) {


                                for (int add = 0 ; add < deep ; add++) {

                                    if (row + add < _maxRow) {

                                        if (_items[row + add,i] == -1) {

                                            listResult.Add (new Vector2(row + add,i));
                                            int w = row + add;
                                            //Debug.Log ("-> ADD Row: " + w + " Col: " + i + " | " + item[w,i]);


                                        }
                                        // IN TESTE
                                        else {

                                            listResult.Clear ();


                                        }
                                        //
                                    }

                                    if (listResult.Count == numberHorizontal * deep) {

                                        
                                      //Debug.Log ("Completed Horizontal searching");
                                        
                                        /*
                                        foreach (var item in listResult) {

                                          Debug.Log ("Item: " + item);

                                        }                                        
                                        */
                                        return listResult;
                                    }

                                    //Max element                                
                                      if (i == _maxCol ) {                             
                                        
                                      //Debug.Log ("Colum Limit");
                                        listResult.Clear ();

                                    }


                                }

                            }
                                            
                           
                            
                            
                            else {

                                //Debug.Log ("There is a GAP in Row: " + row + " Col: " + i + " | " + item[row,i]);

                                listResult.Clear ();

                                //get the whole column test 
                                column = i;

                                //Debug.Log ("-> STOPPED in Row: " + row + " Col: " + column + " | " + item[row,column]);

                                if (_maxCol - column <= numberHorizontal) {

                                    //Debug.Log ("## THERE IS NO HOPE");
                                    column = _maxCol;

                                }

                                break;
                            }
                        }
                    }
                }
                //End Hope
               // else { Debug.Log ("Drop to next row"); }
                // In Test
                listResult.Clear ();
                //
            }
        }


        return listResult;
    }

    private List<Vector2> LookForAreaVerticalPriority (int numberVertical,int deep) {

       

        List<Vector2> listResult = new List<Vector2> ();
        
        int rowSelect = 0;

        //Looking for slot free on Vertical
        for (int column = 0 ; column < _maxCol ; column++) {

            for (int row = 0 ; row < _maxRow ; row++) {


                if (_items[row,column] == -1) {

                    rowSelect = row;

                    //Debug.Log ("------ First Free --------->        Vertical");
                    //Debug.Log ("Row: " + row + " Col: " + column + " | " + item[row,column]);

                    if (_maxRow - row >= numberVertical) {

                        // Debug.Log ("## There is HOPE");


                        for (int i = rowSelect ; i < _maxRow ; i++) {

                            //   Debug.Log ("Long Search");

                            if (HorizontalValidation (i,column,deep)) {

                                for (int add = 0 ; add < deep ; add++) {

                                    if (column + add < _maxCol) {

                                        if (_items[i,column + add] == -1) {

                                            listResult.Add (new Vector2 (i,column + add));

                                            int w = column + add;
                                            //Debug.Log ("-> ADD Row: " + i + " Col: " + w + " | " + item[i,w]);

                                        }
                                        else {

                                           listResult.Clear ();
                                           

                                        }
                                    }                                



                                }

                                if (listResult.Count == numberVertical * deep) {

                                    /*
                                    Debug.Log ("Completed Vertical searching");
                                    
                                    foreach (var item in listResult) {
                                        Debug.Log ("Item: " + item);

                                    }
                                    */

                                    return listResult;
                                }

                                //Max element

                                //It was this way=>
                                //if (i == maxRow - 1) {

                                    if (i == _maxRow )  {

                                    // Debug.Log ("Colum Limit");
                                    listResult.Clear ();
                                }


                            }
                            else {

                                //Debug.Log ("There is a GAP in Column: " + i + " Col: " + column + " | " + item[i,column]);
                                listResult.Clear ();

                                //get the whole column test 
                                row = i;
                                //Debug.Log ("-> STOPPED in Column: " + row + " Col: " + column + " | " + item[row,column]);

                                if (_maxRow - row <= numberVertical) {

                                    //Debug.Log ("## THERE IS NO HOPE");
                                    row = _maxRow;

                                }

                                break;

                            }
                        }
                    }//End Hope
                    else {
                        //Debug.Log ("Drop to next Column");
                        listResult.Clear ();

                    }

                }

            }

        }
       

        return listResult;

    }


    private bool VerticalValidation (int currentRow,int currentColumn,int deepVertical) {
       
        bool result = true;

        if (deepVertical == 1) {

            return result;
        }

        //its was my last added 
        
        if (deepVertical + currentRow > _maxRow) {
            
            return false;
        }
        

        int limit = deepVertical + currentRow;
    

        for (int row = currentRow ; row < limit ; row++) {
                      

            result = result && (_items[row,currentColumn] == -1);
         


        }

        return result;
    }

    private bool HorizontalValidation (int currentRow,int currentColumn,int deepHorizontal) {

        bool result = true;

        if (deepHorizontal == 1) {

            return result;
        }

        //its was my last added 
        if (deepHorizontal + currentColumn > _maxCol) {

            return false;
        }


        int limit = deepHorizontal + currentColumn;


        for (int column = currentColumn ; column < limit ; column++) {

            result = result && (_items[currentRow,column] == -1);
     

        }

        return result;
    }

    
}
