package apps_dohomeapp.dohome.co.th.smarthome_ok_http.Adapter;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.support.annotation.NonNull;
import android.support.constraint.ConstraintLayout;
import android.support.v7.widget.CardView;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.kosalgeek.android.json.JsonConverter;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Model._model_user;
import apps_dohomeapp.dohome.co.th.smarthome_ok_http.R;
import apps_dohomeapp.dohome.co.th.smarthome_ok_http.User_management;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class adapter_user_management extends RecyclerView.Adapter<adapter_user_management.Holder> {

    private String sResponse;
    private JSONObject jsonObject;
    private ArrayList<_model_user> modelJson;
    Activity context;
    ArrayList<_model_user> model_users;
    private adapter_user_management adapter_user;
    private RecyclerView rv_User_management;

    public adapter_user_management(Activity context, ArrayList<_model_user> model_users) {
        this.context = context;
        this.model_users = model_users;
        this.rv_User_management = context.findViewById(R.id.rv_User_management);
    }


    @NonNull
    @Override
    public Holder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_user_management, parent, false);
        Holder holder = new Holder(view);
        return holder;
    }

    @Override
    public void onBindViewHolder(@NonNull Holder holder, final int position) {
        final _model_user item = model_users.get(position);

        holder.tv_usercode.setText(item._user_code);
        holder.tv_username.setText(item._user_name);
        holder.tv_userstate.setText(item._state);
        holder.tv_password.setText(item._password);

        holder.constrainlayout.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                new AlertDialog.Builder(context)
                        .setTitle("ลบข้อมูล")
                        .setMessage("คุณต้องการลบข้อมูลใช่หรือไม่ ?")
                        .setIcon(R.drawable.ic_delete)
                        .setCancelable(false)
                        .setPositiveButton(android.R.string.cancel, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int whichButton) {
                                dialog.dismiss();
                            }
                        })
                        .setNegativeButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                new Get_HTTP_DELETE_USER().execute(item.id);
                                notifyDataSetChanged();
                                notifyItemRemoved(position);
                                notifyItemRangeChanged(position, getItemCount());
                            }
                        })
                        .show();
                return false;
            }
        });
    }

    @Override
    public int getItemCount() {
        if (model_users != null)
            return model_users.size();
        return 0;
    }

    public class Holder extends RecyclerView.ViewHolder {
        TextView tv_usercode, tv_username, tv_userstate, tv_password;
        ConstraintLayout constrainlayout;

        public Holder(View itemView) {
            super(itemView);

            tv_usercode = itemView.findViewById(R.id.tv_usercode);
            tv_username = itemView.findViewById(R.id.tv_username);
            tv_userstate = itemView.findViewById(R.id.tv_userstate);
            tv_password = itemView.findViewById(R.id.tv_password);
            constrainlayout = itemView.findViewById(R.id.constrainlayout);
        }
    }

    public class Get_HTTP_DELETE_USER extends AsyncTask<String, Void, String> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if (s.equalsIgnoreCase("successfully")) {

                new AlertDialog.Builder(context)
                        .setTitle("ลบข้อมูลสำเร็จ")
                        .setMessage(s)
                        .setIcon(R.drawable.ic_delete_green)
                        .setCancelable(false)
                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialogs, int whichButton) {

                                new Get_user().execute();
                                dialogs.dismiss();
                            }
                        }).show();
            }
        }

        @Override
        protected String doInBackground(String... strings) {

            String sUrl = "http://nooartskyline.online/smarthome/app_delete_user.php?id=" + strings[0];
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
                        adapter_user = new adapter_user_management(context, modelJson);
                        rv_User_management.setLayoutManager(new LinearLayoutManager(context));
                        rv_User_management.setAdapter(adapter_user);
                    } else {
                        //ถ้า <= 0
                        new AlertDialog.Builder(context)
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
                new AlertDialog.Builder(context)
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
