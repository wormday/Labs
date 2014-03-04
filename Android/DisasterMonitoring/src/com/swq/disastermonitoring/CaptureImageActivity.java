package com.swq.disastermonitoring;

import java.io.*;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import android.widget.Button;
import android.app.Activity;
import android.view.*;
import android.view.SurfaceHolder.Callback;
import android.os.*;
import android.graphics.Bitmap;
import android.graphics.Bitmap.CompressFormat;
import android.graphics.BitmapFactory;
import android.graphics.ImageFormat;
import android.hardware.*;
import android.util.*;
import android.hardware.Camera.*;

public class CaptureImageActivity extends Activity {
	SurfaceView sView;
	SurfaceHolder surfaceHolder;
	Button btnCapture;
	int screenWidth, screenHeight;
	Camera camera;
	boolean isPreview = false;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		// requestWindowFeature(Window.FEATURE_NO_TITLE);
		// getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
		// WindowManager.LayoutParams.FLAG_FULLSCREEN);
		setContentView(R.layout.capture_image);
		WindowManager wm = getWindowManager();
		Display display = wm.getDefaultDisplay();
		DisplayMetrics metrics = new DisplayMetrics();

		display.getMetrics(metrics);
		sView = (SurfaceView) findViewById(R.id.sView);
		//sView.getHolder().setType(SurfaceHolder.SURFACE_TYPE_PUSH_BUFFERS);
		surfaceHolder = sView.getHolder();

		surfaceHolder.addCallback(new Callback() {
			@Override
			public void surfaceChanged(SurfaceHolder holder, int format,
					int width, int height) {

			}

			@Override
			public void surfaceCreated(SurfaceHolder holder) {
				initCamera();
				Capture();
			}

			@Override
			public void surfaceDestroyed(SurfaceHolder holder) {
				if (camera != null) {
					if (isPreview) {
						camera.stopPreview();
						camera.release();
						camera = null;
					}

				}
			}
		});
	}

	private void initCamera() {
		if (!isPreview) {
			camera = Camera.open(0);
			camera.setDisplayOrientation(90);
		}
		if (camera != null && !isPreview) {
			try {
				Camera.Parameters parameters = camera.getParameters();
				parameters.setPreviewSize(screenWidth, screenHeight);
				parameters.setPreviewFpsRange(4, 10);
				parameters.setPictureFormat(ImageFormat.JPEG);
				parameters.set("jpeg-quality", 85);
				parameters.setPictureSize(screenWidth, screenHeight);
				camera.setPreviewDisplay(surfaceHolder);
				camera.startPreview();
			} catch (Exception e) {
				e.printStackTrace();
			}
			isPreview = true;
		}
	}

	public void Capture() {
		if (camera != null) {
			camera.autoFocus(autoFocusCallback);
			//camera.takePicture(null, null, myJpegCallback);
		}
	}

	AutoFocusCallback autoFocusCallback = new AutoFocusCallback() {
		@Override
		public void onAutoFocus(boolean success, Camera camera) {
			if (success) {
				camera.takePicture(new ShutterCallback() {
					public void onShutter() {

					}
				}, new PictureCallback() {
					public void onPictureTaken(byte[] data, Camera c) {

					}
				}, myJpegCallback);
			}
		}
	};

	PictureCallback myJpegCallback = new PictureCallback() {
		@Override
		public void onPictureTaken(byte[] data, Camera camera) {
			final Bitmap bm = BitmapFactory.decodeByteArray(data, 0,
					data.length);
			SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss",
					Locale.US);
			String path = Environment.getExternalStorageDirectory()
					+ "/DisasterMonitoring";
			File path1 = new File(path);
			if (!path1.exists()) {
				path1.mkdirs();
			}
			File file = new File(path, sdf.format(new Date()) + ".jpg");
			FileOutputStream outStream = null;
			try {
				outStream = new FileOutputStream(file);
				bm.compress(CompressFormat.JPEG, 100, outStream);
				outStream.close();
			} catch (IOException e) {
				e.printStackTrace();

			}
			camera.stopPreview();
			camera.startPreview();
			isPreview = true;
			finish();
		}
	};
}
