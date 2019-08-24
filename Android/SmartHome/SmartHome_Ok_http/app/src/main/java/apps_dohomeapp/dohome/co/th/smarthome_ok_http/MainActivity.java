package apps_dohomeapp.dohome.co.th.smarthome_ok_http;


import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.TextView;

import com.kosalgeek.android.json.JsonConverter;

import org.jetbrains.annotations.NotNull;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Model._model_json;
import io.ghyeok.stickyswitch.widget.StickySwitch;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class MainActivity extends AppCompatActivity {
    String sResponse,getuser_pre,getname_pre;
    private JSONObject jsonObject;
    private ArrayList<_model_json> modelJson;
    private StickySwitch sticky_switch1, sticky_switch2, sticky_switch3, sticky_switch4;
    private SwipeRefreshLayout swipeContainer;
    private SharedPreferences getsharedPre;
    private TextView tv_code_name,tv_regitry;
    private String getState_code,sStatename;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        sticky_switch1 = findViewById(R.id.sticky_switch1);
        sticky_switch2 = findViewById(R.id.sticky_switch2);
        sticky_switch3 = findViewById(R.id.sticky_switch3);
        sticky_switch4 = findViewById(R.id.sticky_switch4);
        swipeContainer = findViewById(R.id.swipeContainer);
        tv_code_name = findViewById(R.id.tv_code_name);
        tv_regitry = findViewById(R.id.tv_regitry);

        Bundle bundle = getIntent().getExtras();
        if (bundle != null) {
            getState_code = bundle.getString("_state_code");
            if(getState_code.equalsIgnoreCase("user")) {
                tv_regitry.setVisibility(View.GONE);
                sStatename = "ผู้ใช้งานทั่วไป";
            }else {
                sStatename = "ผู้ดูแลระบบ";
            }
        }

        //get SharedPreferences
        getsharedPre = getSharedPreferences("SharedPre", MODE_PRIVATE);
        getuser_pre = getsharedPre.getString("user", "");
        getname_pre = getsharedPre.getString("name", "");

        tv_code_name.setText(" รหัสผู้ใช้งาน: " + getuser_pre + "  ชื่อผู้ใช้งาน: " + getname_pre + " สิทธ์: " + sStatename);



        new Get_HTTP().execute();

        tv_regitry.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this,User_management.class);
                startActivity(intent);
            }
        });

        swipeContainer.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {
            @Override
            public void onRefresh() {
                new Get_HTTP().execute();
            }

        });

        sticky_switch1.setOnSelectedChangeListener(new StickySwitch.OnSelectedChangeListener() {
            @Override
            public void onSelectedChange(@NotNull StickySwitch.Direction direction, @NotNull String s) {
                String getValue;
                if (s.equals("ON")) {
                    getValue = "A1";
                } else {
                    getValue = "A0";
                }
                new Get_HTTP_UPdate().execute("1", getValue, getuser_pre);
            }
        });

        sticky_switch2.setOnSelectedChangeListener(new StickySwitch.OnSelectedChangeListener() {
            @Override
            public void onSelectedChange(@NotNull StickySwitch.Direction direction, @NotNull String s) {
                String getValue;
                if (s.equals("ON")) {
                    getValue = "B1";
                } else {
                    getValue = "B0";
                }
                new Get_HTTP_UPdate().execute("2", getValue, getuser_pre);
            }
        });

        sticky_switch3.setOnSelectedChangeListener(new StickySwitch.OnSelectedChangeListener() {
            @Override
            public void onSelectedChange(@NotNull StickySwitch.Direction direction, @NotNull String s) {
                String getValue;
                if (s.equals("ON")) {
                    getValue = "C1";
                } else {
                    getValue = "C0";
                }
                new Get_HTTP_UPdate().execute("3", getValue, getuser_pre);
            }
        });

        sticky_switch4.setOnSelectedChangeListener(new StickySwitch.OnSelectedChangeListener() {
            @Override
            public void onSelectedChange(@NotNull StickySwitch.Direction direction, @NotNull String s) {
                String getValue;
                if (s.equals("ON")) {
                    getValue = "D1";
                } else {
                    getValue = "D0";
                }
                new Get_HTTP_UPdate().execute("4", getValue, getuser_pre);
            }
        });

    }

    public class Get_HTTP extends AsyncTask<String, Void, String> {

        String sUrl = "http://nooartskyline.online/smarthome/app_getstatus_device.php";

        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            swipeContainer.setColorSchemeResources(android.R.color.holo_blue_bright,
                    android.R.color.holo_green_light,
                    android.R.color.holo_orange_light,
                    android.R.color.holo_red_light);

        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if (s != null) {
                try {
                    jsonObject = new JSONObject(s);
                    modelJson = new JsonConverter<_model_json>().toArrayList(jsonObject.get("jsondata").toString(), _model_json.class);
                    Log.i("response", s);
                    swipeContainer.setRefreshing(false);

                    if (modelJson.size() > 0) {

                        for (int i = 0; i < modelJson.size(); i++) {

                            if (modelJson.get(i)._status_device.equals("A1")) {
                                sticky_switch1.setDirection(StickySwitch.Direction.RIGHT);
                            }
                            if (modelJson.get(i)._status_device.equals("A0")) {
                                sticky_switch1.setDirection(StickySwitch.Direction.LEFT);
                            }
                            if (modelJson.get(i)._status_device.equals("B1")) {
                                sticky_switch2.setDirection(StickySwitch.Direction.RIGHT);
                            }
                            if (modelJson.get(i)._status_device.equals("B0")) {
                                sticky_switch2.setDirection(StickySwitch.Direction.LEFT);
                            }
                            if (modelJson.get(i)._status_device.equals("C1")) {
                                sticky_switch3.setDirection(StickySwitch.Direction.RIGHT);
                            }
                            if (modelJson.get(i)._status_device.equals("C0")) {
                                sticky_switch3.setDirection(StickySwitch.Direction.LEFT);
                            }
                            if (modelJson.get(i)._status_device.equals("D1")) {
                                sticky_switch4.setDirection(StickySwitch.Direction.RIGHT);
                            }
                            if (modelJson.get(i)._status_device.equals("D0")) {
                                sticky_switch4.setDirection(StickySwitch.Direction.LEFT);
                            }
                        }

                    } else {
                        //ถ้า <= 0
                    }


                } catch (JSONException e) {
                    e.printStackTrace();
                }
            } else {
                //ถ้าเป็น Null
                new Get_HTTP().execute();
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

    public class Get_HTTP_UPdate extends AsyncTask<String, Void, String> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            swipeContainer.setColorSchemeResources(android.R.color.holo_blue_bright,
                    android.R.color.holo_green_light,
                    android.R.color.holo_orange_light,
                    android.R.color.holo_red_light);

        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            swipeContainer.setRefreshing(false);
        }

        @Override
        protected String doInBackground(String... strings) {

            String sUrl = "http://nooartskyline.online/smarthome/app_update.php?id=" + strings[0] + "&_status_device=" + strings[1] + "&_user_update=" + strings[2];
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
