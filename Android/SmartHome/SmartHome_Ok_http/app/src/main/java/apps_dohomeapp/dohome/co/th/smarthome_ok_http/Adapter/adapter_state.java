package apps_dohomeapp.dohome.co.th.smarthome_ok_http.Adapter;

import android.app.Activity;
import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;

import apps_dohomeapp.dohome.co.th.smarthome_ok_http.Model._model_permission;
import apps_dohomeapp.dohome.co.th.smarthome_ok_http.R;

public class adapter_state extends BaseAdapter {
    Activity mContext;ArrayList<_model_permission> list_item;
    public _model_permission item;
    LayoutInflater inflter;

    public adapter_state(Activity mContext, ArrayList<_model_permission> list_item) {
        this.mContext = mContext;
        this.list_item = list_item;
        inflter = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
//        inflter = (LayoutInflater.from(mContext));
    }

    @Override
    public int getCount() {
        if(list_item!=null)
            return list_item.size();
        return 0;
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        item = list_item.get(position);
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        convertView = inflter.inflate(R.layout.item_sp_state,null);
        TextView tv_item_state = convertView.findViewById(R.id.tv_item_state);
        tv_item_state.setText(list_item.get(position)._state_code + " : " + list_item.get(position)._state_name);
        return convertView;
    }
}
