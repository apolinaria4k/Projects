package com.example.project1;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;

public class Min extends AppCompatActivity
{
     ArrayAdapter<String> arad;
    ArrayList<String> stringArrayList;
     ListView listView;
     EditText editText1, editText2;
    Button add, addToList, clear;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.layout);

        editText1 = (EditText) findViewById(R.id.et1);
        editText2 = (EditText) findViewById(R.id.et2);
        stringArrayList = new ArrayList<>();
        listView = (ListView) findViewById(R.id.vw);
        arad = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, stringArrayList);
        listView.setAdapter(arad);
        add = (Button) findViewById(R.id.add);
        addToList = (Button) findViewById(R.id.addToList);
        clear = (Button) findViewById(R.id.clear);
    }

    public void Add(View view){
        int kolvo = Integer.valueOf(editText2.getText().toString());
        String edittext = editText1.getText().toString();
        if(kolvo>20){
            kolvo = 20;
            for(int i = 1; i<=kolvo; i++){
                edittext += "#";
                editText1.setText(edittext);
            }
        }
        else{
            for(int i = 1; i<=kolvo; i++){
                edittext += "#";
                editText1.setText(edittext);
            }
        }
    }

    public void Clear(View view){
        arad.clear();
    }

    public void AddToList(View view){
        String edittext = editText1.getText().toString();
        arad.add(edittext);
    }
}
