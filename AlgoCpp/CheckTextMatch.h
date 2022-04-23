#pragma once
#include<fstream>
#include<istream>
#include<iostream>
#include<string>
#include <nlohmann/json.hpp>

using json = nlohmann::json;
namespace CheckTextMatch_namespace {
	using nlohmann::json;


	inline json get_untyped(const json& j, const char* property) {
		if (j.find(property) != j.end()) {
			return j.at(property).get<json>();
		}
		return json();
	}

	inline json get_untyped(const json& j, std::string property) {
		return get_untyped(j, property.data());
	}

	class CheckTextMatch {
	public:
		CheckTextMatch() = default;
		virtual ~CheckTextMatch() = default;

	private:
		double match_score;
		double avg_color;
		double threshold;
		double heigh_tolerance;
		double width_tolerance;
		double area_tolerance;
		//--mod sept21
		double fontHeightTol;
		double fontWidthTol;
		double shiftXTol;
		double shiftYTol;
		//--
		int64_t point_a_x;
		int64_t point_a_y;
		int64_t point_b_x;
		int64_t point_b_y;
		std::string template_image_path;



	public:
		const double& get_match_score() const { return match_score; }
		double& get_mutable_match_score() { return match_score; }
		void set_match_score(const double& value) { this->match_score = value; }

		const double& get_avg_color() const { return avg_color; }
		double& get_mutable_avg_color() { return avg_color; }
		void set_avg_color(const double& value) { this->avg_color = value; }

		const double& get_threshold() const { return threshold; }
		double& get_mutable_threshold() { return threshold; }
		void set_threshold(const double& value) { this->threshold = value; }

		const double& get_heigh_tolerance() const { return heigh_tolerance; }
		double& get_mutable_heigh_tolerance() { return heigh_tolerance; }
		void set_heigh_tolerance(const double& value) { this->heigh_tolerance = value; }

		const double& get_width_tolerance() const { return width_tolerance; }
		double& get_mutable_width_tolerance() { return width_tolerance; }
		void set_width_tolerance(const double& value) { this->width_tolerance = value; }

		const double& get_area_tolerance() const { return area_tolerance; }
		double& get_mutable_area_tolerance() { return area_tolerance; }
		void set_area_tolerance(const double& value) { this->area_tolerance = value; }

//--------------mod sept21
		const double& get_fontHeight_tolerance() const { return fontHeightTol; }
		double& get_mutable_fontHeight_tolerance() { return fontHeightTol; }
		void set_fontHeight_tolerance(const double& value) { this->fontHeightTol = value; }

		const double& get_fontWidth_tolerance() const { return fontWidthTol; }
		double& get_mutable_fontWidth_tolerance() { return fontWidthTol; }
		void set_fontWidth_tolerance(const double& value) { this->fontWidthTol = value; }

		const double& get_shiftX_tolerance() const { return shiftXTol; }
		double& get_mutable_shiftX_tolerance() { return shiftXTol; }
		void set_shiftX_tolerance(const double& value) { this->shiftXTol = value; }

		const double& get_shiftY_tolerance() const { return shiftYTol; }
		double& get_mutable_shiftY_tolerance() { return shiftYTol; }
		void set_shiftY_tolerance(const double& value) { this->shiftYTol = value; }

		//---------

		const int64_t& get_point_a_x() const { return point_a_x; }
		int64_t& get_mutable_point_a_x() { return point_a_x; }
		void set_point_a_x(const int64_t& value) { this->point_a_x = value; }

		const int64_t& get_point_a_y() const { return point_a_y; }
		int64_t& get_mutable_point_a_y() { return point_a_y; }
		void set_point_a_y(const int64_t& value) { this->point_a_y = value; }

		const int64_t& get_point_b_x() const { return point_b_x; }
		int64_t& get_mutable_point_b_x() { return point_b_x; }
		void set_point_b_x(const int64_t& value) { this->point_b_x = value; }

		const int64_t& get_point_b_y() const { return point_b_y; }
		int64_t& get_mutable_point_b_y() { return point_b_y; }
		void set_point_b_y(const int64_t& value) { this->point_b_y = value; }

		const std::string& get_template_image_path() const { return template_image_path; }
		std::string& get_mutable_template_image_path() { return template_image_path; }
		void set_template_image_path(const std::string& value) { this->template_image_path = value; }
	};

	void from_json(const json& j, CheckTextMatch_namespace::CheckTextMatch& x);
	void to_json(json& j, const CheckTextMatch_namespace::CheckTextMatch& x);

	inline void from_json(const json& j, CheckTextMatch_namespace::CheckTextMatch& x) {
		x.set_match_score(j.at("matchScore").get<double>());
		x.set_avg_color(j.at("avgColor").get<double>());
		x.set_threshold(j.at("threshold").get<double>());
		x.set_heigh_tolerance(j.at("heighTolerance").get<double>());
		x.set_width_tolerance(j.at("widthTolerance").get<double>());
		x.set_area_tolerance(j.at("areaTolerance").get<double>());
//-------
		x.set_fontHeight_tolerance(j.at("fontHeightTol").get<double>());
		x.set_fontWidth_tolerance(j.at("fontWidthTol").get<double>());
		x.set_shiftX_tolerance(j.at("shiftXTol").get<double>());
		x.set_shiftY_tolerance(j.at("shiftYTol").get<double>());
//---
		x.set_point_a_x(j.at("point_a_x").get<int64_t>());
		x.set_point_a_y(j.at("point_a_y").get<int64_t>());
		x.set_point_b_x(j.at("point_b_x").get<int64_t>());
		x.set_point_b_y(j.at("point_b_y").get<int64_t>());
		x.set_template_image_path(j.at("template_image_path").get<std::string>());
	}

	inline void to_json(json& j, const CheckTextMatch_namespace::CheckTextMatch& x) {
		j = json::object();
		j["matchScore"] = x.get_match_score();
		j["avgColor"] = x.get_avg_color();
		j["threshold"] = x.get_threshold();
		j["heighTolerance"] = x.get_heigh_tolerance();
		j["widthTolerance"] = x.get_width_tolerance();
		j["areaTolerance"] = x.get_area_tolerance();
		//--
		j["fontHeightTol"]=x.get_fontHeight_tolerance();
		j["fontWidthTol"]=x.get_fontWidth_tolerance();
		j["shiftXTol"] = x.get_shiftX_tolerance();
		j["shiftYTol"] = x.get_shiftY_tolerance();
		//---
		j["point_a_x"] = x.get_point_a_x();
		j["point_a_y"] = x.get_point_a_y();
		j["point_b_x"] = x.get_point_b_x();
		j["point_b_y"] = x.get_point_b_y();
		j["template_image_path"] = x.get_template_image_path();
	}

}