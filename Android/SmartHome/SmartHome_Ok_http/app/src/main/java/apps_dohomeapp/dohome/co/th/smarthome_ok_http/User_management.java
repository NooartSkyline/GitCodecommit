package apps_dohomeapp.dohome.co.th.smarthome_ok_http;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

import com.kosalgeek.android.json.JsonConverter;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Adapter.adapter_state;
import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Adapter.adapter_user_management;
import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Model._model_permission;
import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Model._model_user;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class User_management extends AppCompatActivity {
    private RecyclerView rv_User_management;
    private adapter_user_management adapter_user;
    private JSONObject jsonObject;
    private ArrayList<_model_user> modelJson;
    private String sResponse, sCode, sName, sPass, sState;
    private EditText ed_code, ed_name, ed_pass;
    private Button btn_add;
    private ArrayList<_model_permission> list_state;
    private Spinner sp_state;
    private adapter_state adapterState;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_management);
        rv_User_management = findViewById(R.id.rv_User_management);
        ed_code = findViewById(R.id.ed_code);
        ed_name = findViewById(R.id.ed_name);
        ed_pass = findViewById(R.id.ed_pass);
        sp_state = findViewById(R.id.sp_state);
        btn_add = findViewById(R.id.btn_add);

        GetState();
        new Get_user().execute();

        btn_add.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int iCode = ed_code.getText().length();
                int iName = ed_name.getText().length();
                int iPass = ed_pass.getText().length();

                if (iCode < 1 || iName < 1 || iPass < 1 ) {
                    if (iCode < 1) {
                        ed_code.requestFocus();
                        ed_code.setError("ใส่รหัสผู้ใช้งาน");
                    }
                    if (iName < 1) {
                        ed_name.requestFocus();
                        ed_name.setError("ใส่ชื่อผู้ใช้งาน");
                    }
                    if (iPass < 1) {
                        ed_pass.requestFocus();
                        ed_pass.setError("ใส่รหัสผ่านผู้ใช้งาน");
                    }
                }else {
                    sCode = ed_code.getText().toString();
                    sName = ed_name.getText().toString();
                    sPass = ed_pass.getText().toString();
                    sState = list_state.get(sp_state.getSelectedItemPosition())._state_code;

                    new Get_HTTP_INSERT_USER().execute(sCode, sName, sPass, sState);
                }
            }
        });
    }

    public class Get_user extends AsyncTask<String, Void, String> {

        String sUrl = "http://nooartskyline.online/smarthome/app_getuser.php";

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if (s != null) {
                try {
                    jsonObject = new JSONObject(s);
                    modelJson = new JsonConverter<_model_user>().toArrayList(jsonObject.get("jsondata").toString(), _model_user.class);
                    Log.i("response", s);

                    if (modelJson.size() > 0) {
                        adapter_user = new adapter_user_management(User_management.this, modelJson);
                        rv_User_management.setLayoutManager(new LinearLayoutManager(User_management.this));
                        rv_User_management.setAdapter(adapter_user);
                    } else {
                        //ถ้า <= 0
                        new AlertDialog.Builder(User_management.this)
                                .setTitle("แจ้ง!")
                                .setMessage("ไม่พบข้อมูล..!")
                                .setIcon(R.drawable.ic_info)
                                .setCancelable(false)
                                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialogs, int whichButton) {
                                        dialogs.dismiss();
                                    }
                                }).show();

                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }
            } else {
                //ถ้าเป็น Null
                new AlertDialog.Builder(User_management.this)
                        .setTitle("แจ้ง!")
                        .setMessage("เกิดข้อผิดพลาดขณะดึงข้อมูล...!")
                        .setIcon(R.drawable.ic_info)
                        .setCancelable(false)
                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialogs, int whichButton) {
                                dialogs.dismiss();
                            }
                        }).show();

            }

        }

        @Override
        protected String doInBackground(String... strings) {

            try {
                OkHttpClient client = new OkHttpClient();
                Request request = new Request.Builder().url(sUrl).build();

                Response response = client.newCall(request).execute();
                sResponse = response.body().string();
                Log.e("response", sResponse);
                return sResponse;

            } catch (Exception e) {
                e.printStackTrace();
            }

            return null;
        }
    }

    public class Get_HTTP_INSERT_USER extends AsyncTask<String, Void, String> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if(s.equalsIgnoreCase("successfully")){

                new AlertDialog.Builder(User_management.this)
                        .setTitle("เพิ่มข้อมูลเรียบร้อย")
                        .setMessage(s)
                        .setIcon(R.drawable.ic_succ)
                        .setCancelable(false)
                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialogs, int whichButton) {
                                ed_code.setText("");
                                ed_name.setText("");
                                ed_pass.setText("");
                                new Get_user().execute();
                                dialogs.dismiss();
                            }
                        }).show();
            }
        }

        @Override
        protected String doInBackground(String... strings) {

            String sUrl = "http://nooartskyline.online/smarthome/app_insert_user.php?_user_code=" + strings[0] + "&_user_name=" + strings[1] + "&_password=" + strings[2] + "&&_state=" + strings[3];
            try {
                OkHttpClient client = new OkHttpClient();
                Request request = new Request.Builder().url(sUrl).build();

                Response response = client.newCall(request).execute();
                sResponse = response.body().string();
                Log.e("response", sResponse);
                return sResponse;

            } catch (Exception e) {
                e.printStackTrace();
            }

            return null;
        }
    }

    public void GetState(){

        list_state = new ArrayList<>();
        _model_permission item = new _model_permission();
        item._state_code = "admin";
        item._state_name = "ผู้ดูแลระบบ";
        list_state.add(item);

        _model_permission item2 = new _model_permission();
        item2._state_code = "user";
        item2._state_name = "ผู้ใช้งานทั่วไป";
        list_state.add(item2);

        adapterState = new adapter_state(User_management.this,list_state);
        sp_state.setAdapter(adapterState);
    }

}
