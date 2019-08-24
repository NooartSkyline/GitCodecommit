package apps_dohomeapp.dohome.co.th.smarthome_ok_http;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.kosalgeek.android.json.JsonConverter;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Model._model_user;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class Login extends AppCompatActivity {
    private EditText ed_user, ed_password;
    String sResponse, sGetuser, sGetpassword;
    private JSONObject jsonObject;
    private ArrayList<_model_user> modelJson;
    private Button btn_cancel, btn_login;
    private SharedPreferences getsharedPre;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        ed_user = findViewById(R.id.ed_user);
        ed_password = findViewById(R.id.tv_password);
        btn_cancel = findViewById(R.id.btn_cancel);
        btn_login = findViewById(R.id.btn_login);

        btn_cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        btn_login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
//                new Get_user().execute();
                //เขียน SharedPreferences
                SharedPreferences.Editor editor = getSharedPreferences("SharedPre", MODE_PRIVATE).edit();
                editor.putString("user", "11111");
                editor.putString("name", "อาร์ต");
                editor.commit();

                Intent intent = new Intent(Login.this, MainActivity.class);
                intent.putExtra("_state_code", "admin");
                startActivity(intent);

//                                ed_user.setText("");
                ed_password.setText("");
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

                        int iUser = ed_user.getText().toString().length();
                        int iIntpassword = ed_password.getText().toString().length();

                        if (iUser < 1 && iIntpassword < 1) {
                            if (iUser <= 0) {
                                ed_user.requestFocus();
                                ed_user.setError("กรุณากรอกรหัสผู้ใช้งาน");
                            } else {
                                ed_password.requestFocus();
                                ed_password.setError("กรุณากรอกรหัสผ่าน");
                            }

                        } else {
                            sGetuser = ed_user.getText().toString();
                            sGetpassword = ed_password.getText().toString();
                        }

                        for (_model_user i : modelJson) {

                            if (i._user_code.equals(sGetuser) && i._password.equals(sGetpassword)) {

                                //เขียน SharedPreferences
                                SharedPreferences.Editor editor = getSharedPreferences("SharedPre", MODE_PRIVATE).edit();
                                editor.putString("user", i._user_code);
                                editor.putString("name", i._user_name);
                                editor.commit();

                                Intent intent = new Intent(Login.this, MainActivity.class);
                                intent.putExtra("_state_code", i._state);
                                startActivity(intent);

//                                ed_user.setText("");
                                ed_password.setText("");
                                break;

                            } else {
//                                new AlertDialog.Builder(Login.this)
//                                        .setTitle("แจ้ง!")
//                                        .setMessage("ไม่พบผู้ใชงาน..!")
//                                        .setIcon(R.drawable.ic_info)
//                                        .setCancelable(false)
//                                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
//                                            public void onClick(DialogInterface dialogs, int whichButton) {
//                                                dialogs.dismiss();
//                                            }
//                                        }).show();
                            }
                        }

                    } else {
                        //ถ้า <= 0
                        new AlertDialog.Builder(Login.this)
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
                new AlertDialog.Builder(Login.this)
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
}
