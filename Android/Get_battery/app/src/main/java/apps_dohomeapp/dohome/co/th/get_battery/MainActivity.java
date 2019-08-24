package apps_dohomeapp.dohome.co.th.get_battery;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.media.MediaPlayer;
import android.os.BatteryManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;

public class MainActivity extends AppCompatActivity {
    private TextView tv_levelbat;
    private ArrayList<Boolean> asd;
    private Boolean isCharging, usbCharge, acCharge;
    private int Level;
    MediaPlayer player = null;
    ImageView imv_Battery;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tv_levelbat = findViewById(R.id.tv_levelbat);
        imv_Battery = findViewById(R.id.imv_Battery);


        this.registerReceiver(receiver, new IntentFilter(Intent.ACTION_BATTERY_CHANGED));

        tv_levelbat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (player != null) {
                    player.release();
                }
            }
        });

    }

    private BroadcastReceiver receiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            Level = intent.getIntExtra(BatteryManager.EXTRA_LEVEL, -1);
            int status = intent.getIntExtra(BatteryManager.EXTRA_STATUS, -1);
            isCharging = status == BatteryManager.BATTERY_STATUS_CHARGING ||
                    status == BatteryManager.BATTERY_STATUS_FULL;

            int chargePlug = intent.getIntExtra(BatteryManager.EXTRA_PLUGGED, -1);
            usbCharge = chargePlug == BatteryManager.BATTERY_PLUGGED_USB;
            acCharge = chargePlug == BatteryManager.BATTERY_PLUGGED_AC;
//            tv_levelbat.setText(String.valueOf(isCharging) + ": " + String.valueOf(usbCharge) + ": " + String.valueOf(acCharge) +" %"+ String.valueOf(Level));
            tv_levelbat.setText(String.valueOf(Level) + " %");

            if(usbCharge == false && acCharge == false){
                if (Level == 100) {
                    imv_Battery.setImageResource(R.drawable.ic_battery_full);
                    tv_levelbat.setText(String.valueOf(Level) + " %");
//                tv_levelbat.setTextColor(getResources().getColor(R.color.red));

                    player = MediaPlayer.create(MainActivity.this, R.raw.google);
                    if (player != null) {
                        player.start();
                    }
                } else if(Level >= 90){
                    imv_Battery.setImageResource(R.drawable.ic_battery_90);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 80){
                    imv_Battery.setImageResource(R.drawable.ic_battery_80);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 60){
                    imv_Battery.setImageResource(R.drawable.ic_battery_60);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 50){
                    imv_Battery.setImageResource(R.drawable.ic_battery_50);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 30){
                    imv_Battery.setImageResource(R.drawable.ic_battery_30);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 20){
                    imv_Battery.setImageResource(R.drawable.ic_battery_20);
                    if (player != null) {
                        player.release();
                    }
                }
            }else {
                if (Level == 100) {
                    imv_Battery.setImageResource(R.drawable.ic_battery_charging_full);
                    tv_levelbat.setText(String.valueOf(Level) + " % \n ถอดที่ชาร์ต!!");
//                tv_levelbat.setTextColor(getResources().getColor(R.color.red));

                    player = MediaPlayer.create(MainActivity.this, R.raw.google);
                    if (player != null) {
                        player.start();
                    }
                } else if(Level >= 90){
                    imv_Battery.setImageResource(R.drawable.ic_battery_charging_90);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 80){
                    imv_Battery.setImageResource(R.drawable.ic_battery_charging_80);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 60){
                    imv_Battery.setImageResource(R.drawable.ic_battery_charging_60);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 50){
                    imv_Battery.setImageResource(R.drawable.ic_battery_charging_50);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 30){
                    imv_Battery.setImageResource(R.drawable.ic_battery_charging_30);
                    if (player != null) {
                        player.release();
                    }
                }else if(Level >= 20){
                    imv_Battery.setImageResource(R.drawable.ic_battery_charging_20);
                    if (player != null) {
                        player.release();
                    }
                }
            }

        }
    };
}
